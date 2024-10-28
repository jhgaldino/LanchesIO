using FluentValidation;
using FluentValidation.Results;
using LanchesIO.API.src.Interfaces;
using LanchesIO.API.src.Models;
using LanchesIO.API.src.Services;
using LanchesIO.API.src.Validations;
using Microsoft.AspNetCore.Mvc;

namespace LanchesIO.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngredienteController : ControllerBase
    {
        private readonly IIngredienteService _ingredienteService;
        private readonly IValidator<Ingrediente> _validator;

        public IngredienteController(IIngredienteService ingredienteService)
        {
            _ingredienteService = ingredienteService;
            _validator = new IngredienteValidation();
        }

/// <summary>
/// Lista todos os ingredientes
/// </summary>
/// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ingrediente>>> GetIngredientes()
        {
            var ingredientes = await _ingredienteService.GetIngredientesAsync();
            return Ok(ingredientes);
        }

/// <summary>
/// Busca um ingrediente pelo id
/// </summary>
/// <param name="id"></param>
/// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Ingrediente>> GetIngrediente(int id)
        {
            var ingrediente = await _ingredienteService.GetIngredienteAsync(id);
            if (ingrediente == null)
            {
                return NotFound();
            }
            return Ok(ingrediente);
        }

/// <summary>
/// Cria um novo ingrediente
/// </summary>
/// <param name="ingrediente"></param>
/// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Ingrediente>> CreateIngrediente(Ingrediente ingrediente)
        {
            ValidationResult result = await _validator.ValidateAsync(ingrediente);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            var createdIngrediente = await _ingredienteService.CreateIngredienteAsync(ingrediente);
            return CreatedAtAction(nameof(GetIngrediente), new { id = createdIngrediente.Id }, createdIngrediente);
        }

/// <summary>
/// Atualiza um ingrediente pelo id
/// </summary>
/// <param name="id"></param>
/// <param name="updatedIngrediente"></param>
/// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateIngrediente(int id, Ingrediente updatedIngrediente)
        {
            ValidationResult result = await _validator.ValidateAsync(updatedIngrediente);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            var updateResult = await _ingredienteService.UpdateIngredienteAsync(id, updatedIngrediente);
            if (!updateResult)
            {
                return NotFound();
            }
            return NoContent();
        }

/// <summary>
/// Deleta um ingrediente pelo id
/// </summary>
/// <param name="id"></param>
/// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteIngrediente(int id)
        {
            var result = await _ingredienteService.DeleteIngredienteAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
