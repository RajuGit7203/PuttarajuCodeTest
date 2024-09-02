using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mouri.Shared;
using Mouri_Api.JWT;

namespace Mouri_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;        
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost()]
        [Route("token")]        
        public IActionResult Token(User user)
        {
            var token = _userService.Login(user);
            if (token == null || token == string.Empty)
            {
                return BadRequest(new { message = "UserName or Password is incorrect" });
            }
            return Ok(token);
        }
    }
}
