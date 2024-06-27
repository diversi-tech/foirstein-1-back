using BLL.interfaces;
using DAL.functions;
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
        public UsersController(Iuser_bll user)
        {
            this.user = user;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(user.GetAll());

        }
        [HttpPut("reset-password")]
        public ActionResult ResetPassword([FromBody] ResetPasswordRequest request)
        {
            user.ResetPassword(request.IdNumber, request.NewPassword);
            return Ok(new { message = "Password reset successfully." });
        }
       

        [HttpPost("verify-security-questions")]
        public ActionResult VerifySecurityQuestions([FromBody] VerifySecurityQuestionsRequest request)
        {
            var result = user.VerifySecurityQuestions(request.IdNumber);
            if (result != null)
            {
                return Ok(new { message = "Verification successful." });
            }
            return BadRequest(new { message = "Invalid credentials." });
        }
    }

    public class ForgotPasswordRequest
    {
        public string Email { get; set; }
    }
    public class VerifySecurityQuestionsRequest
    {
        public string IdNumber { get; set; }
    }
    public class ResetPasswordRequest
    {
        public string IdNumber { get; set; }
        public string NewPassword { get; set; }
    }

}
