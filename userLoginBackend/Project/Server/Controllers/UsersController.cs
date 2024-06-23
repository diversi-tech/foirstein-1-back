using DAL.Interfaces;
using DAL.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace userLoginBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        Iuser user;
        public UsersController(Iuser user)
        {
            this.user = user;
        }
        [HttpGet]
        public ActionResult<List<User>> GetAll()
        {
            return Ok(user.GetAll());
            
        }

    }
}
