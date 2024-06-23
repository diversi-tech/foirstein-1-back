using DAL.Interfaces;
using DAL.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.functions
{
    public class userDal : Iuser
    {
        LoginContext loginContext;
        public userDal(LoginContext loginContext)
        {

            this.loginContext = loginContext;

        }
        public List<User> GetAll()
        {
            return loginContext.Users.ToList();
        }

        public User Add(User user)
        {
            loginContext.Users.Add(user);
            loginContext.SaveChanges();
            return user;
        }

        public bool Update(User user)
        {
            var existingUser = loginContext.Users.Find(user.UserId);
            if (existingUser == null)
            {
                return false;
            }

            existingUser.Username = user.Username;
            existingUser.Email = user.Email;
            // עדכני תכונות נוספות לפי הצורך

            loginContext.Users.Update(existingUser);
            loginContext.SaveChanges();
            return true;
        }

        public bool Delete(User user)
        {
            var existingUser = loginContext.Users.Find(user.UserId);
            if (existingUser == null)
            {
                return false;
            }
            loginContext.Users.Remove(existingUser);
            loginContext.SaveChanges();
            return true;
        }
    }
}


