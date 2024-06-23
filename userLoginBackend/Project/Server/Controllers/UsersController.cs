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
        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequest request)
        {
            //var result = await user.SendPasswordResetLink(request.Email);
            //if (result)
            //{
            //    return Ok(new { message = "Password reset link sent." });
            //}
            return BadRequest(new { message = "User not found." });
        }
    }

    public class ForgotPasswordRequest
    {
        public string Email { get; set; }
    }

}
