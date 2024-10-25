using LanchesIO.API.src.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;

namespace LanchesIO.API.src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Realiza o login do usuário.
        /// </summary>
        /// <param name="userLogin">Dados de login do usuário.</param>
        /// <returns>Token JWT se o login for bem-sucedido.</returns>
        [HttpPost("login")]
        [ProducesResponseType(typeof(OkObjectResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Login([FromBody] UserLogin userLogin)
        {
            // Validação simples de usuário
            if (userLogin.Username == "admin" && userLogin.Password == "password")
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                string? jwtKey = _configuration["Jwt:Key"];
                if (string.IsNullOrEmpty(jwtKey))
                {
                    return StatusCode(500, "Chave JWT não configurada.");
                }
                byte[] key = Encoding.ASCII.GetBytes(jwtKey);
                using var hmac = new HMACSHA256(key);
                var signingKey = new SymmetricSecurityKey(hmac.Key);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, userLogin.Username)
                    }),
                    Expires = DateTime.UtcNow.AddHours(1),
                    SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);

                return Ok(new { Token = tokenString });
            }

            return Unauthorized();
        }
    }
}