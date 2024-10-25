// AuthService.cs
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using LanchesIO.API.Interfaces;
using LanchesIO.API.src.Models;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using LanchesIO.API.Controllers;
using Moq;

namespace LanchesIO.API.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly byte[] _key;
        private readonly Mock<IAuthService> _mockAuthService;
        private readonly AuthController _authController;

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
            var jwtKey = _configuration["Jwt:Key"];
            if (string.IsNullOrEmpty(jwtKey))
            {
                throw new ArgumentNullException(nameof(jwtKey), "JWT key cannot be null or empty.");
            }
            _key = Convert.FromBase64String(jwtKey);
            _mockAuthService = new Mock<IAuthService>();
            _authController = new AuthController(_mockAuthService.Object);
        }

        public async Task<LoginResponse?> LoginAsync(string username, string password)
        {
            // Implement the method logic here
            return await Task.FromResult<LoginResponse?>(null); // Placeholder implementation
        }

        // Rest of the code...  
    }
}