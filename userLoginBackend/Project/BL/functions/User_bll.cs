using AutoMapper;
using BLL.AutoMapper;
using BLL.interfaces;
using BLL.models_bll;
using DAL.functions;
using DAL.Interfaces;
using DAL.models;
using System;
using System.Collections.Generic;
using System.Linq;
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
            User userDal=_Iuser.Update(mapper.Map<User>(user));
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
        public string ValidateUser(string UserName, string password)
        {
            List<User_modelBll> users = getall();
            var userDtos = mapper.Map<List<User_modelBll>>(users);

            var user = users.FirstOrDefault(u => u.UserName == UserName);

            if (user == null)
            {
                return "משתמש לא קיים";
            }

            if (user.PasswordHash == password)
            {
                return "משתמש קיים";
            }
            else
            {
                return "סיסמה שגויה";
            }
        }
    }
}
