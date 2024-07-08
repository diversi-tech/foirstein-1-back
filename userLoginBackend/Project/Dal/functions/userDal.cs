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
        LiberiansDbContext LiberiansDbContext;
        public userDal(LiberiansDbContext LiberiansDbContext)
        {

            this.LiberiansDbContext = LiberiansDbContext;

        }
        public List<User> GetAll()
        {
            return LiberiansDbContext.Users.ToList();
        }

        public int Add(User user)
        {
            LiberiansDbContext.Users.Add(user);
            LiberiansDbContext.SaveChanges();
            return user.UserId;
        }

        public User Update(User user)
        {
            var existingUser = LiberiansDbContext.Users.Find(user.UserId);
            if (existingUser == null)
            {
                return null;
            }

            existingUser.UserName = user.UserName;
            existingUser.Email = user.Email;
            // עדכני תכונות נוספות לפי הצורך

            LiberiansDbContext.Users.Update(existingUser);
            LiberiansDbContext.SaveChanges();
            return existingUser;
        }

        public bool Delete(int userId)
        {
            User existingUser = LiberiansDbContext.Users.Find(userId);
            if (existingUser == null)
            {
                return false;
            }
            LiberiansDbContext.Users.Remove(existingUser);
            LiberiansDbContext.SaveChanges();
            return true;
        }

        public User UpdatePassword(User user)
        {
            var existingUser = LiberiansDbContext.Users.Find(user.UserId);
            if (existingUser == null)
            {
                return null;
            }
            existingUser.PasswordHash = user.PasswordHash;
            LiberiansDbContext.Users.Update(existingUser);
            LiberiansDbContext.SaveChanges();
            return existingUser;

        }
    }
}


