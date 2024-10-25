// AuthController.cs
using LanchesIO.API.Interfaces;
using LanchesIO.API.Services;
using LanchesIO.API.src.Models;
using Microsoft.AspNetCore.Mvc;

namespace LanchesIO.API.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLogin userLogin)
        {
            var token = _authService.Authenticate(userLogin.Username, userLogin.Password);
            if (token == null)
                return Unauthorized();

            return Ok(new { token });
        }
    }
}