using BLL.interfaces;
using BLL.models_bll;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace userLoginBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApprovalRequestController : ControllerBase
    {
        IApprovalRequest_bll IApprovalRequest_bll;
        public ApprovalRequestController(IApprovalRequest_bll iApprovalRequest_bll)
        {
            IApprovalRequest_bll = iApprovalRequest_bll;
        }
        [HttpGet("GetAllApprovalRequest")]
        public ActionResult<List<ApprovalRequestBll>> GetAll()
        {
            return Ok(IApprovalRequest_bll.GetAll());
        }
    }
}
