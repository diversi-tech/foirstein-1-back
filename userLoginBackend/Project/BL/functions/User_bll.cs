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
        public List<models_bll.User_bll> getall()
        {
            List<User> users = _Iuser.GetAll();
            return mapper.Map<List<models_bll.User_bll>>(users);
        }

        public models_bll.User_bll Add(models_bll.User_bll user)
        {
            try
            {
                User u = _Iuser.Add(mapper.Map<User>(user));

                return mapper.Map<models_bll.User_bll>(u);
            }
            catch
            {
                return null;
            }
        }

        public models_bll.User_bll Update(models_bll.User_bll user)
        {
            // מיפוי מ-User_bll ל-User
            User userDal=_Iuser.Update(mapper.Map<User>(user));
            // קריאה לפונקציה Update ב-DA
            return mapper.Map<models_bll.User_bll>(userDal);
        }

        public bool Delete(string userId)
        {
            return _Iuser.Delete(userId);
        }
    }
}
