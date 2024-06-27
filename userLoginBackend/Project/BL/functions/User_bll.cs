using AutoMapper;
using BLL.interfaces;
using BLL.models_bll;
using DAL.Interfaces;
using DAL.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace BLL.functions
{
    public class User_bll : Iuser_bll
    {
        Iuser Iuser;
        IMapper mapper;

        public User_bll(Iuser user,IMapper mapper)
        {
            this.Iuser = user;
            this.mapper = mapper;
        }

        public List<models_bll.User_bll> GetAll()
        {
            List<User> users = Iuser.GetAll();
            return mapper.Map<List<models_bll.User_bll>>(users);
        }

        public models_bll.User_bll VerifySecurityQuestions(string idNumber)
        {
            User user = Iuser.GetAll().FirstOrDefault(u =>u.UserId == idNumber );
            if (user != null)
            {
                // Return the user details if the verification is successful
                models_bll.User_bll user_Bll = mapper.Map<models_bll.User_bll>(user);
                return user_Bll;
            }
            return null;
        }

   
  
    



        public models_bll.User_bll ResetPassword(string IdNumber, string NewPassword)
        {

            var user = Iuser.GetAll().FirstOrDefault(u => u.UserId == IdNumber);
                if (user == null)
                {
                    throw new Exception("User not found");
                }

            models_bll.User_bll user_Bll = mapper.Map<models_bll.User_bll>(user);
            user_Bll.PasswordHash = NewPassword;
            user_Bll.UpdatedAt = DateTime.Now;
            Iuser.UpdatePassword(mapper.Map<User>(user_Bll));
            return user_Bll;
            }
        }
    }

