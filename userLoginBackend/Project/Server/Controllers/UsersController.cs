using BLL;
using BLL.interfaces;
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
        Iuser_bll user;
        ErrorManager errorManager;
        public UsersController(Iuser_bll user,ErrorManager errorManager)
        {
            this.user = user;
           this.errorManager = errorManager;
        }
        [HttpGet]
        public ActionResult<List<User>> GetAll()
        {
            return Ok(user.GetAll());
            
        }
        [HttpPost("signup")]
        public IActionResult Signup(string username, string password)
        {
            string result = errorManager.Signup(username, password);

            if (string.IsNullOrEmpty(result))
            {
                return Ok("המשתמש נרשם בהצלחה");
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpPost("signin")]
        public IActionResult Signin(string username, string password)
        {
            string result = errorManager.Signin(username, password);

            if (string.IsNullOrEmpty(result))
            {
                return Ok("המשתמש נרשם בהצלחה");
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
