using BLL.functions;
using BLL.interfaces;
using BLL.models_bll;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace userLoginBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityLogController : ControllerBase
    {
        IActivityLog_bll _IActivityLog_bll;
        public ActivityLogController(IActivityLog_bll IActivityLog_bll)
        {
            this._IActivityLog_bll = IActivityLog_bll;
        }
        [HttpGet("GetAllActivity")]
        public ActionResult<List<ActivityLog_modelBll>> GetAll()
        {
            return Ok(_IActivityLog_bll.getall());

        }
    }
}
