using LanchesIO.API.Controllers;
using LanchesIO.API.Interfaces;
using LanchesIO.API.src.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace LanchesIO.API.Tests
{
    public class AuthTests
    {
        private readonly Mock<IAuthService> _mockAuthService;
        private readonly AuthController _authController;

        public AuthTests()
        {
            _mockAuthService = new Mock<IAuthService>();
            _authController = new AuthController(_mockAuthService.Object);
        }

        [Fact]
        public async Task Login_ReturnsOkResult_WithToken()
        {
            // Arrange
            var userLogin = new UserLogin { Username = "testuser", Password = "password" };
            var token = new LoginResponse { Token = "valid_token" };
            _mockAuthService.Setup(service => service.LoginAsync(userLogin.Username, userLogin.Password))
                            .ReturnsAsync(token);

            // Act
            var result = await _authController.Login(userLogin);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<dynamic>(okResult.Value);
            Assert.Equal("valid_token", returnValue.token);
        }

        [Fact]
        public async Task Login_ReturnsUnauthorized_WhenCredentialsAreInvalid()
        {
            // Arrange
            var userLogin = new UserLogin { Username = "testuser", Password = "wrongpassword" };
            _mockAuthService.Setup(service => service.LoginAsync(userLogin.Username, userLogin.Password))
                            .ReturnsAsync((LoginResponse?)null);

            // Act
            var result = await _authController.Login(userLogin);

            // Assert
            Assert.IsType<UnauthorizedResult>(result);
        }
    }
}
