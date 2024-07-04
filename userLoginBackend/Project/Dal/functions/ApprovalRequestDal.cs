using DAL.Interfaces;
using DAL.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.functions
{
    public class ApprovalRequestDal : IapprovalRequest
    {

        LiberiansDbContext LiberiansDbContext;
        public ApprovalRequestDal(LiberiansDbContext liberiansDbContext)
        {
            LiberiansDbContext = liberiansDbContext;
        }
        public List<BorrowApprovalRequest> GetAll()
        {
            return LiberiansDbContext.BorrowApprovalRequests.ToList();
        }
    }
}
