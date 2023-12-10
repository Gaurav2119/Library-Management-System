using lms.DataAccess;
using lms.DataAccess.Abstract;
using lms.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser useraccess;
        public UserController(IUser user)
        {
            useraccess = user;
        }

        [HttpGet("Login")]
        public IActionResult Login(string username, string password)
        {
            var user = useraccess.authenticate(username, password);

            if (user != null)
            {
                var gtoken = new jwt().CreateJwt(user);
                return Ok(gtoken);
            }

            return Ok("Invalid Credentials!");
        }

        [HttpGet("Token/{userid}")]
        public IActionResult token(int userid)
        {
            var user = useraccess.GetUser(userid);

            if (user == null)
            {
                return Ok("User not found");
            }

            return Ok(user.token);
        }
    }
}