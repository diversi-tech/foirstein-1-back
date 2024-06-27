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
        public ActionResult<List<User_bll>> GetAll()
        {
            return Ok(user.getall());
            
        }
        [HttpPost("addUser")]
        public ActionResult<User_bll> add(User_bll u)
        {
            return Ok(user.Add(u));
        }
        [HttpPut("updateUser")]
        public ActionResult<User_bll> update(User_bll u)
        {
            try
            {
                User_bll result = user.Update(u);
                return result;
            }

            catch (Exception ex)
            {
                return null;   
            }
        }

        [HttpDelete("dellUser/{id}")]
        public ActionResult<bool> dell(string id)
        {
            return Ok(user.Delete(id));
        }
      

    }
}
