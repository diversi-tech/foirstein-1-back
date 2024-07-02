using AutoMapper;
using BLL.interfaces;
using DAL.Interfaces;
using DAL.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.functions
{
    public class User_bll : Iuser_bll
    {
        Iuser user;
        IMapper _mapper;
        public User_bll(Iuser user, IMapper m)
        {

            this.user = user;
            _mapper = m;

        }

        public List<User_bll> GetAll()
        {
            throw new NotImplementedException();
        }
        public bool PasswordMatches(string username, string password)
        {
            return user.PasswordMatches(username, password);
        }


    }
}

