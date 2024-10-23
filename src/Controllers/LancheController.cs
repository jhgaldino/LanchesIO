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
    public class LancheController : ControllerBase
    {
        private readonly LancheService _lancheService;

        public LancheController(LancheService lancheService)
        {
            _lancheService = lancheService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lanche>>> GetLanches()
        {
            return Ok(await _lancheService.GetLanchesAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Lanche>> GetLanche(int id)
        {
            var lanche = await _lancheService.GetLancheByIdAsync(id);
            if (lanche == null)
            {
                return NotFound();
            }
            return Ok(lanche);
        }

        [HttpPost]
        public async Task<ActionResult<Lanche>> AddLanche([FromBody] Lanche lanche)
        {
            var createdLanche = await _lancheService.AddLancheAsync(lanche);
            return CreatedAtAction(nameof(GetLanche), new { id = createdLanche.Id }, createdLanche);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateLanche(int id, [FromBody] Lanche updatedLanche)
        {
            var result = await _lancheService.UpdateLancheAsync(id, updatedLanche);
            if (!result)
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
