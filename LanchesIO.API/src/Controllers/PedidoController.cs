using FluentValidation;
using FluentValidation.Results;
using LanchesIO.API.src.Interfaces;
using LanchesIO.API.src.Models;
using LanchesIO.API.src.Validations;
using Microsoft.AspNetCore.Mvc;

namespace LanchesIO.API.src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;
        private readonly IValidator<Pedido> _validator;

        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
            _validator = new PedidoValidation();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pedido>>> GetPedidos()
        {
            var pedidos = await _pedidoService.GetPedidosAsync();
            return Ok(pedidos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pedido>> GetPedido(int id)
        {
            var pedido = await _pedidoService.GetPedidoAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }
            return Ok(pedido);
        }

        [HttpPost]
        public async Task<ActionResult<Pedido>> CreatePedido(Pedido pedido)
        {
            ValidationResult result = await _validator.ValidateAsync(pedido);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            var createdPedido = await _pedidoService.CreatePedidoAsync(pedido);
            return CreatedAtAction(nameof(GetPedido), new { id = createdPedido.Id }, createdPedido);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePedido(int id, Pedido updatedPedido)
        {
            ValidationResult result = await _validator.ValidateAsync(updatedPedido);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            var updateResult = await _pedidoService.UpdatePedidoAsync(id, updatedPedido);
            if (!updateResult)
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
