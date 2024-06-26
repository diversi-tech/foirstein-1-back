using DAL.Interfaces;
using DAL.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password.ToString()));
                var hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
                return hash;
            }
        }

        public bool UserExists(string username)
        {
           return loginContext.Users.Any(user => user.Username == username );

        }
        public bool PasswordMatches(string username, string password)
        {
            string hashedPassword = HashPassword(password);

            return loginContext.Users.Any(user => user.Username == username && user.PasswordHash == hashedPassword);
        }

    }
    }



