using LanchesIO.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LanchesIO.Services;


namespace LanchesIO.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly PedidoService _pedidoService;

        public PedidoController(PedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pedido>>> GetPedidos()
        {
            return Ok(await _pedidoService.GetPedidosAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pedido>> GetPedido(int id)
        {
            var pedido = await _pedidoService.GetPedidoByIdAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }
            return Ok(pedido);
        }

        [HttpPost]
        public async Task<ActionResult<Pedido>> AddPedido([FromBody] Pedido pedido)
        {
            var createdPedido = await _pedidoService.AddPedidoAsync(pedido);
            return CreatedAtAction(nameof(GetPedido), new { id = createdPedido.Id }, createdPedido);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePedido(int id, [FromBody] Pedido updatedPedido)
        {
            var result = await _pedidoService.UpdatePedidoAsync(id, updatedPedido);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePedido(int id)
        {
            var result = await _pedidoService.DeletePedidoAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }

    
}
