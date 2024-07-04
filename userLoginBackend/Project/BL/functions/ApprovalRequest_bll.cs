using AutoMapper;
using BLL.AutoMapper;
using BLL.interfaces;
using BLL.models_bll;
using DAL.Interfaces;
using DAL.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.functions
{
    public class ApprovalRequest_bll : IApprovalRequest_bll
    {
        IapprovalRequest IapprovalRequest;
        IMapper _mapper;
        public ApprovalRequest_bll(IapprovalRequest iapprovalRequest, IMapper mapper)
        {
            IapprovalRequest = iapprovalRequest;
            _mapper = mapper;
        }
        public List<ApprovalRequestBll> GetAll()
        {
            List<BorrowApprovalRequest> a = IapprovalRequest.GetAll();
            return _mapper.Map<List<ApprovalRequestBll>>(a);
        }
    }
}
