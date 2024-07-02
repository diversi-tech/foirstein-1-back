using BLL.functions;
using BLL.interfaces;
using BLL.models_bll;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
<<<<<<< HEAD
using System.Numerics;
=======
using System.Diagnostics;
>>>>>>> elishevaBack

namespace userLoginBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityLogController : ControllerBase
    {
        IActivityLog_bll _IActivityLog_bll;
<<<<<<< HEAD
        public ActivityLogController(IActivityLog_bll _ActivityLog_bll)
        {
            this._IActivityLog_bll = _ActivityLog_bll;
        }
        [HttpGet("getAllLogs")]
        public ActionResult<List<ActivityLog_bll>> GetAll()
=======
        public ActivityLogController(IActivityLog_bll IActivityLog_bll)
        {
            this._IActivityLog_bll = IActivityLog_bll;
        }
        [HttpGet("GetAllActivity")]
        public ActionResult<List<ActivityLog_modelBll>> GetAll()
>>>>>>> elishevaBack
        {
            return Ok(_IActivityLog_bll.getall());

        }
    }
}
