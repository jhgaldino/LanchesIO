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

        /// <summary>
        /// Authenticates a user and returns a JWT token.
        /// </summary>
        /// <param name="userLogin">The user login details.</param>
        /// <returns>A JWT token if authentication is successful.</returns>
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LoginResponse))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login([FromBody] UserLogin userLogin)
        {
            var token = await _authService.LoginAsync(userLogin.Username, userLogin.Password);
            if (token is null)
                return Unauthorized();

            return Ok(token);
        }
    }
}