using BLL.functions;
using BLL.interfaces;
using BLL.models_bll;
using Microsoft.AspNetCore.Mvc;

namespace userLoginBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrarianPermissionsController : ControllerBase
    {
        private readonly ILibrarianPermissionsBll I_bllService;

        public LibrarianPermissionsController(ILibrarianPermissionsBll bllService)
        {
            I_bllService = bllService;
        }

        [HttpPut("updatePermissions")]
        public ActionResult UpdatePermissions([FromBody] libper l)
        {
            var result = I_bllService.UpdatePermission(l.UserId, l.P);
            if (result != null)
            {
                return Ok(new { success = true });
            }
            else
            {
                return BadRequest(new { success = false });
            }
        }

        public class libper
        {
            public int UserId { get; set; }
            public string[] P { get; set; }
        }
    }
}
