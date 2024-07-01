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
        public ActionResult<User_modelBll> add(User_modelBll u)
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
      

    }
}
