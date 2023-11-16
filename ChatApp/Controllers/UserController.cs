using ChatApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace ChatApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private List<User> _users;

        public UserController(List<User> users)
        {
            _users = users;
        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody] User user)
        {

            if(_users.Where(x => x.Login == user.Login).Contains(user))
                return BadRequest("This user already exist");
            
            _users.Add(user);
            return Ok();
        }

        [HttpGet("Login")]
        public IActionResult Login([FromBody] User user)
        {
            if (_users.Contains(user))
            {
                return Ok();
            }
            return BadRequest("Invalid data");
        }
        
    }
}
