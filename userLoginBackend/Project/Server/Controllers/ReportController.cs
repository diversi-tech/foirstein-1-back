using BLL.interfaces;
using BLL.models_bll;
using DAL.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace userLoginBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        IReport_bll _IReport_bll;
        public ReportController(IReport_bll IReport_bll)
        {
            this._IReport_bll = IReport_bll;
        }
        [HttpGet("getReports")]
        public ActionResult<List<Report_modelBll>> GetAll()
        {
            return Ok(_IReport_bll.getall());

        }


    }
}
