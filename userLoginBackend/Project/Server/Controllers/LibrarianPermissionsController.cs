using BLL.functions;
using BLL.interfaces;
using BLL.models_bll;
using Microsoft.AspNetCore.Mvc;

namespace userLoginBackend.Controllers
{
    public class LibrarianPermissionsController
    {
        private readonly ILibrarianPermissionsBll I_bllService;

        public LibrarianPermissionsController(ILibrarianPermissionsBll bllService)
        {
            I_bllService = bllService;
        }

        [HttpPut("updatePermissions")]
        public ActionResult<LibrarianPermissionBll> UpdatePermissions(libper l)
        {
            return I_bllService.UpdatePermission(l.UserId,l.P);
           
        }
        public class libper
        {
            public int UserId { get; set; }
            public string [] P { get; set; }
        }
    }
}
