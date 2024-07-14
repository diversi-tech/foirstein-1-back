﻿using BLL.functions;
using BLL.models_bll;
using DAL.functions;
using DAL.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BLL.functions.User_bll;

namespace BLL.interfaces
{
    public interface Iuser_bll
    {
        List<User_modelBll> getall();
        User_modelBll Add(User_modelBll user);
       User_modelBll Update(User_modelBll user);
        bool Delete(int userId);
        public User_modelBll VerifySecurityQuestions(string idNumber);

        public User_modelBll ResetPassword(string IdNumber, string NewPassword);

        public Response ValidateUser(string UserName, string password);

        public bool UpdateUserRole(int userId, string newRole);
        //public TokenValidationResponse ValidateToken(string token);

    }
}