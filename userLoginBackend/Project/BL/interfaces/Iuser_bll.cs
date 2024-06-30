using DAL.functions;
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
        List<models_bll.User_bll> getall();
        models_bll.User_bll Add(models_bll.User_bll user);
        models_bll.User_bll Update(models_bll.User_bll user);
        bool Delete(int userId);

    }
}
