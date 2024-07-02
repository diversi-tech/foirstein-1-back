using BLL.interfaces;
using DAL.functions;
using DAL.Interfaces;
using DAL.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using BLL.models_bll;


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
        public ActionResult<User_modelBll> add([FromForm] User_modelBll u)
        {
            return Ok(user.Add(u));
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
        public ActionResult<bool> dell(int id)
        {
            return Ok(user.Delete(id));
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
        [HttpGet("{name}/{pass}")]
        public ActionResult<string> getUser(string name, string pass)
        {
            return Ok(user.ValidateUser(name, pass));

        }
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

