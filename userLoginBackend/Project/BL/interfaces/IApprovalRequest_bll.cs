using BLL.models_bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.interfaces
{
    public interface IApprovalRequest_bll
    {

        public List<ApprovalRequestBll> GetAll();

    }
}
