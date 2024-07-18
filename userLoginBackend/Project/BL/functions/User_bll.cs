using AutoMapper;
using BLL.AutoMapper;
using BLL.interfaces;
using BLL.models_bll;
using DAL.functions;
using DAL.Interfaces;
using DAL.models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Librarians.Repository.Repository;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using System.Web;

namespace BLL.functions
{
    public class User_bll : Iuser_bll
    {
        Iuser _Iuser;
        static IMapper mapper;
        private readonly GmailSMTP _gmailSmtpClient;
       public string s="";
        public User_bll(Iuser iUser, IConfiguration configuration)
        {
            _Iuser = iUser;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });
            mapper = (IMapper)config.CreateMapper();
            string gmailAddress = configuration["Gmail:Address"];
            string gmailPassword = configuration["Gmail:Password"];
            _gmailSmtpClient = new GmailSMTP(gmailAddress, gmailPassword);
        }



        public List<User_modelBll> getall()
        {
            List<User> users = _Iuser.GetAll();

            return mapper.Map<List<User_modelBll>>(users);
        }

        public User_modelBll Add(User_modelBll user)
        {
            try
            {
                User u = _Iuser.Add(mapper.Map<User>(user));

                return mapper.Map<User_modelBll>(u);
            }
            catch
            {
                return null;
            }
        }

        public User_modelBll Update(User_modelBll user)
        {
            // מיפוי מ-User_bll ל-User
            User userDal = _Iuser.Update(mapper.Map<User>(user));
            // קריאה לפונקציה Update ב-DA
            return mapper.Map<User_modelBll>(userDal);
        }

        public bool Delete(int userId)
        {
            return _Iuser.Delete(userId);
        }

        public User_modelBll VerifySecurityQuestions(string idNumber)
        {
            User user = _Iuser.GetAll().FirstOrDefault(u => u.Tz == idNumber);
            if (user != null)
            {
                User_modelBll user_Bll = mapper.Map<User_modelBll>(user);
                return user_Bll;
            }
            return null;
        }

        public User_modelBll ResetPassword(int UserId, string NewPassword)
        {
            var user = _Iuser.GetAll().FirstOrDefault(u => u.UserId == UserId);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            User_modelBll user_Bll = mapper.Map<User_modelBll>(user);
            user_Bll.PasswordHash = NewPassword;
            user_Bll.UpdatedAt = DateTime.Now;
            _Iuser.UpdatePassword(mapper.Map<User>(user_Bll));
            return user_Bll;
        }
        public bool UpdateUserRole(int userId, string newRole)
        {
            var user = _Iuser.GetAll().FirstOrDefault(x => x.UserId == userId);
            if (user == null)
            {
                return false; // אם המשתמש לא נמצא
            }

            user.Role = newRole;
            _Iuser.Update(user); // אין צורך במיפוי כאן כי כבר יש לך את ה-user
            return true;
        }
        public Response ValidateUser(string tz, string password)
        {
            List<User_modelBll> users = getall();
            var userDtos = mapper.Map<List<User_modelBll>>(users);
            var user = users.FirstOrDefault(u => u.Tz == tz);
            if (user == null)
            {
                return null;
            }
            if (user.PasswordHash == password)
            {
                var token = GenerateJwtToken(user);
                return new Response
                {
                    token = token,
                    User = new UserLogin
                    {
                        Role = user.Role,
                       // UserName = user.UserName,
                        Tz = user.Tz
                    }
                };
            }
            else
            {
                return new Response
                {
                    token = null,
                    User = new UserLogin
                    {
                        Role = user.Role,
                       // UserName = user.UserName,
                        Tz = user.Tz
                    }
                };
            }
        }
        public TokenValidationResponse ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes("YourSuperSecretKeyThatIsAtLeast32CharactersLong");
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var tz = jwtToken.Claims.First(x => x.Type == "tz").Value;
                var user = getall().FirstOrDefault(u => u.Tz == tz);

                if (user == null)
                {
                    return new TokenValidationResponse
                    {
                        IsValid = false
                    };
                }

                return new TokenValidationResponse
                {
                    IsValid = true,
                    User = new UserLogin
                    {
                        UserName = $"{user.Fname} {user.Sname}",
                Role = user.Role,
                        Tz = user.Tz
                    }
                };
            }
            catch
            {
                return new TokenValidationResponse
                {
                    IsValid = false
                };
            }
        }



        public User SendPasswordResetLink(string email)
        {
            User u = _Iuser.GetAll().FirstOrDefault(u => u.Email == email);
            if (u != null)
            {
                var userDtos = mapper.Map<User_modelBll>(u);
                string token = GenerateJwtToken(userDtos);
                string userName = $"{u.Fname} {u.Sname}";
                string body = $@"
<html>
<head>
    <meta charset='UTF-8'>
    <style>
        body {{
            direction: rtl;
            text-align: right;
            font-size: 18px;
        }}
        a {{
            font-size: 20px;
        }}
        p {{
            margin: 0 0 10px 0;
        }}
    </style>
</head>
<body>
    <p>{userName} היקר,</p>
    <p>הגשת בקשה לאיפוס סיסמה. אנא לחץ על הקישור הבא לאיפוס הסיסמה שלך:</p>
    <p><a href='https://foirstein-1-front-aojx.onrender.com/#/reset-password?token={HttpUtility.UrlEncode(token)}'>אפס סיסמה</a></p>
    <p>אם לא הגשת בקשה זו, תוכל להתעלם מהודעה זו בבטחה.</p>
    <p>בברכה,<br>צוות האתר שלך</p>
    <hr>
    <p>הודעה זו נשלחה ממערכת אוטומטית. אין להשיב על הודעה זו.</p>
</body>
</html>";

                _gmailSmtpClient.SendEmail(email, "איפוס סיסמא", body);
            }
            return u;
        }







        private string GenerateJwtToken(User_modelBll user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("YourSuperSecretKeyThatIsAtLeast32CharactersLong"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var username = $"{user.Fname} {user.Sname}";
            var claims = new[]
            {
        new Claim(JwtRegisteredClaimNames.Sub, username),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        new Claim(ClaimTypes.Role, user.Role),
        new Claim("tz", user.Tz),
         new Claim("userId", user.UserId.ToString()),
    };

            var token = new JwtSecurityToken(
                issuer: "yourdomain.com",
                audience: "yourdomain.com",
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public class UserLogin
        {
            public string Tz { get; set; }
            public string UserName { get; set; }
            public string Role { get; set; }
        }
        public class Response
        {
            public string token { get; set; }
            public UserLogin User { get; set; }


        }
        public class TokenValidationResponse
        {
            public bool IsValid { get; set; }
            public UserLogin User { get; set; }
        }

    }
}
