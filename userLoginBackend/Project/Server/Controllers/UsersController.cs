using BLL.interfaces;
using DAL.functions;
using DAL.Interfaces;
using DAL.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using BLL.models_bll;
using static BLL.functions.User_bll;

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
        [HttpGet("getUsers")]
        public ActionResult<List<User_modelBll>> GetAll()
        {
            return Ok(user.getall());

        }
        [HttpPost("addUser")]
        public ActionResult add([FromForm] User_modelBll u)
        {
            var userId = user.Add(u);
            var response = new
            {
                message = "User added successfully",
                userId = userId
            };
            return Ok(response);
        }

        [HttpPut("updateUser")]
        public ActionResult<User_modelBll> update(User_modelBll u)
        {
            try
            {
                User_modelBll result = user.Update(u);
                return result;
            }

            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpDelete("dellUser/{id}")]
        public ActionResult dell(int id)
        {
            var result = user.Delete(id);
            if (result)
            {
                var response = new
                {
                    message = "User removed successfully"
                };
                return Ok(response);
            }
            else
            {
                return NotFound(new { message = "User not found" });
            }
        }

        [HttpPut("reset-password")]
        public ActionResult ResetPassword([FromBody] ResetPasswordRequest request)
        {
            user.ResetPassword(request.IdNumber, request.NewPassword);
            return Ok(new { message = "Password reset successfully." });
        }


        [HttpGet("verify-security-questions")]
        public ActionResult VerifySecurityQuestions([FromQuery] string idNumber)
        {
            return Ok(user.VerifySecurityQuestions(idNumber));
        }
        [HttpPost("login")]
        public ActionResult<Response> getUser([FromBody] LoginInfo loginInfo)
        {
            return Ok(user.ValidateUser(loginInfo.name, loginInfo.pass));
        }
        [HttpPut("{userId}/role")]
        public IActionResult UpdateUserRole(int userId, [FromBody] User_modelBll userDto)
        {
            var succes = user.UpdateUserRole(userId, userDto.Role);
            if (succes)
            {
                return Ok(new { succes = true });
            }
            else
            {
                return BadRequest(new { success = false, message = "Failed to update user role." });
            }
          
        }
        [HttpPost("validate-token")]
        public ActionResult<Response> validToken([FromBody] string token)
        {
            return Ok(user.ValidateToken(token));
        }
        public class LoginInfo
        {
            public string name { get; set; }
            public string pass { get; set; }
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
}

