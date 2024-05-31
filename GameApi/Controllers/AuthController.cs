using GameApi.DAL.Interfaces;
using GameApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IUserRepository _user;
        public AuthController(ITokenService tokenService, IUserRepository user)
        {
            _tokenService = tokenService;
            _user = user;
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserViewModel usr)
        {
            var isValidUser = _user.ValidateUser(usr);
            //var user = User.Users.FirstOrDefault(x => x.Username == model.Username && x.Password == model.Password);
            if (isValidUser == false) return Unauthorized();

            var token = _tokenService.GenerateToken(usr);
            // This JWT token contains authenticated user details, such as roles, regions, etc.
            return Ok(new { token });
        }
    }
}
