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
    }
}
