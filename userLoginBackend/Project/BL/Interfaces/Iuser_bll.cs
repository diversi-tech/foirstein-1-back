using BLL.functions;
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

       public List<User_bll> GetAll();
       
    }
}
