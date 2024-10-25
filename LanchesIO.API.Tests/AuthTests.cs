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
            var token = new LoginResponse { Token = "valid_token", Expiration = DateTime.UtcNow.AddHours(1) };
            _mockAuthService.Setup(service => service.LoginAsync(userLogin.Username, userLogin.Password))
                            .ReturnsAsync(token);

            // Act
            var result = await _authController.Login(userLogin);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = okResult.Value as LoginResponse;
            Assert.NotNull(returnValue); // Verifica se returnValue não é nulo
            Assert.Equal("valid_token", returnValue!.Token); // Usa o operador de negação nula
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
