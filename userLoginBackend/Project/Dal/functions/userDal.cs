using DAL.Interfaces;
using DAL.models;
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
        public User Add(User user)
        {
            throw new NotImplementedException();
        }

        public int Delete(User user)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
           return loginContext.Users.ToList();
        }

        public User Update(User user, string id)
        {
            throw new NotImplementedException();
        }
    }
}
