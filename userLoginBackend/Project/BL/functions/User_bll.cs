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
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL.functions
{
    public class User_bll : Iuser_bll
    {
        Iuser _Iuser;
        static IMapper mapper;
        public User_bll(Iuser iUser)
        {
            _Iuser = iUser;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });
            mapper = (IMapper)config.CreateMapper();
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

        public User_modelBll ResetPassword(string IdNumber, string NewPassword)
        {
            var user = _Iuser.GetAll().FirstOrDefault(u => u.Tz == IdNumber);
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
        public Response ValidateUser(string UserName, string password)
        {
            List<User_modelBll> users = getall();
            var userDtos = mapper.Map<List<User_modelBll>>(users);

            var user = users.FirstOrDefault(u => u.UserName == UserName);

            if (user == null)
            {
                return null;
            }

            if (user.PasswordHash == password)
            {
                return new Response
                {
                    token = "1234",
                    User = new UserLogin
                    {
                        Role = user.Role,
                        UserName = user.UserName,
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
                        UserName = user.UserName,
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
                var userName = jwtToken.Claims.First(x => x.Type == JwtRegisteredClaimNames.Sub).Value;
                var user = getall().FirstOrDefault(u => u.UserName == userName);

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
                        UserName = user.UserName,
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


        private string GenerateJwtToken(User_modelBll user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("YourSuperSecretKeyThatIsAtLeast32CharactersLong"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
        new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        new Claim(ClaimTypes.Role, user.Role),
        new Claim("tz", user.Tz)
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
