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
    public class LancheController : ControllerBase
    {
        private readonly ILancheService _lancheService;
        private readonly IValidator<Lanche> _validator;

        public LancheController(ILancheService lancheService)
        {
            _lancheService = lancheService;
            _validator = new LancheValidation();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lanche>>> GetLanches()
        {
            var lanches = await _lancheService.GetLanchesAsync();
            return Ok(lanches);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Lanche>> GetLanche(int id)
        {
            var lanche = await _lancheService.GetLancheAsync(id);
            if (lanche == null)
            {
                return NotFound();
            }
            return Ok(lanche);
        }

        [HttpPost]
        public async Task<ActionResult<Lanche>> CreateLanche(Lanche lanche)
        {
            ValidationResult result = await _validator.ValidateAsync(lanche);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            var createdLanche = await _lancheService.CreateLancheAsync(lanche);
            return CreatedAtAction(nameof(GetLanche), new { id = createdLanche.Id }, createdLanche);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateLanche(int id, Lanche updatedLanche)
        {
            ValidationResult result = await _validator.ValidateAsync(updatedLanche);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            var updateResult = await _lancheService.UpdateLancheAsync(id, updatedLanche);
            if (!updateResult)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteLanche(int id)
        {
            var result = await _lancheService.DeleteLancheAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
