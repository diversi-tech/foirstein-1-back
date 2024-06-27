﻿using DAL.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface Iuser
    {
        List<User> GetAll();
        User Add(User user);
        bool Update(User user);
        bool Delete(User user);
        bool UpdatePassword(User user);

    }
}