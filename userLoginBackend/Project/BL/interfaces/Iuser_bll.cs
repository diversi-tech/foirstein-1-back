using Azure.Core;
using BLL.functions;
using BLL.models_bll;
using DAL.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.interfaces
{
    public interface Iuser_bll
    {
       
        public List<models_bll.User_bll> GetAll();
        public models_bll.User_bll VerifySecurityQuestions(string idNumber);

        public models_bll.User_bll ResetPassword(string IdNumber, string NewPassword);
    }
}
