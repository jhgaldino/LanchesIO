using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LanchesIO.src.Services;
using LanchesIO.src.Models;

namespace LanchesIO.src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngredienteController : ControllerBase
    {
        private readonly IngredienteService _ingredienteService;

        public IngredienteController(IngredienteService ingredienteService)
        {
            _ingredienteService = ingredienteService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ingrediente>>> GetIngredientes()
        {
            return Ok(await _ingredienteService.GetIngredientesAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ingrediente>> GetIngrediente(int id)
        {
            var ingrediente = await _ingredienteService.GetIngredienteByIdAsync(id);
            if (ingrediente == null)
            {
                return NotFound();
            }
            return Ok(ingrediente);
        }

        [HttpPost]
        public async Task<ActionResult<Ingrediente>> AddIngrediente([FromBody] Ingrediente ingrediente)
        {
            var createdIngrediente = await _ingredienteService.AddIngredienteAsync(ingrediente);
            return CreatedAtAction(nameof(GetIngrediente), new { id = createdIngrediente.Id }, createdIngrediente);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateIngrediente(int id, [FromBody] Ingrediente updatedIngrediente)
        {
            var result = await _ingredienteService.UpdateIngredienteAsync(id, updatedIngrediente);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

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
