using LanchesIO.API.Controllers;
using LanchesIO.API.src.Interfaces;
using LanchesIO.API.src.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace LanchesIO.API.Tests
{
    public class ApitUnitTests
    {
        private readonly Mock<IIngredienteService> _mockService;
        private readonly IngredienteController _controller;

        public ApitUnitTests()
        {
            _mockService = new Mock<IIngredienteService>();
            _controller = new IngredienteController(_mockService.Object);
        }

        [Fact]
        public async Task GetIngredientes_ReturnsOkResult_WithListOfIngredientes()
        {
            // Arrange
            var ingredientes = new List<Ingrediente>
                {
                    new Ingrediente { Id = 1, Nome = "Tomate", Valor = 1.5M },
                    new Ingrediente { Id = 2, Nome = "Alface", Valor = 0.5M }
                };
            _mockService.Setup(service => service.GetIngredientesAsync()).ReturnsAsync(ingredientes);

            // Act
            var result = await _controller.GetIngredientes();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<List<Ingrediente>>(okResult.Value);
            Assert.Equal(2, returnValue.Count);
        }

        [Fact]
        public async Task GetIngrediente_ReturnsNotFound_WhenIngredienteDoesNotExist()
        {
            // Arrange
            _mockService.Setup(service => service.GetIngredienteAsync(It.IsAny<int>())).ReturnsAsync((Ingrediente)null);

            // Act
            var result = await _controller.GetIngrediente(1);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task GetIngrediente_ReturnsOkResult_WithIngrediente()
        {
            // Arrange
            var ingrediente = new Ingrediente { Id = 1, Nome = "Tomate", Valor = 1.5M };
            _mockService.Setup(service => service.GetIngredienteAsync(1)).ReturnsAsync(ingrediente);

            // Act
            var result = await _controller.GetIngrediente(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<Ingrediente>(okResult.Value);
            Assert.Equal(ingrediente.Id, returnValue.Id);
        }

        [Fact]
        public async Task CreateIngrediente_ReturnsCreatedAtAction_WithValidIngrediente()
        {
            // Arrange
            var ingrediente = new Ingrediente { Id = 1, Nome = "Tomate", Valor = 1.5M };
            _mockService.Setup(service => service.CreateIngredienteAsync(It.IsAny<Ingrediente>())).ReturnsAsync(ingrediente);

            // Act
            var result = await _controller.CreateIngrediente(ingrediente);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var returnValue = Assert.IsType<Ingrediente>(createdAtActionResult.Value);
            Assert.Equal(ingrediente.Id, returnValue.Id);
        }

        [Fact]
        public async Task DeleteIngrediente_ReturnsNotFound_WhenIngredienteDoesNotExist()
        {
            // Arrange
            _mockService.Setup(service => service.DeleteIngredienteAsync(It.IsAny<int>())).ReturnsAsync(false);

            // Act
            var result = await _controller.DeleteIngrediente(1);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task DeleteIngrediente_ReturnsNoContent_WhenIngredienteIsDeleted()
        {
            // Arrange
            _mockService.Setup(service => service.DeleteIngredienteAsync(It.IsAny<int>())).ReturnsAsync(true);

            // Act
            var result = await _controller.DeleteIngrediente(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}