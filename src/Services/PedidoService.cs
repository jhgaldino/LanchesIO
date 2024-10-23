using LanchesIO.src.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace LanchesIO.src.Services
{
    public class PedidoService
    {
        private static List<Pedido> pedidos = new List<Pedido>();

        public Task<IEnumerable<Pedido>> GetPedidosAsync()
        {
            return Task.FromResult(pedidos.AsEnumerable());
        }

        public Task<Pedido?> GetPedidoByIdAsync(int id)
        {
            var pedido = pedidos.FirstOrDefault(p => p.Id == id);
            return Task.FromResult(pedido);
        }

        public Task<Pedido> AddPedidoAsync(Pedido pedido)
        {
            pedido.Id = pedidos.Count > 0 ? pedidos.Max(p => p.Id) + 1 : 1;
            pedidos.Add(pedido);
            return Task.FromResult(pedido);
        }

        public Task<bool> UpdatePedidoAsync(int id, Pedido updatedPedido)
        {
            var pedido = pedidos.FirstOrDefault(p => p.Id == id);
            if (pedido == null)
            {
                return Task.FromResult(false);
            }
            pedido.Lanches = updatedPedido.Lanches;
            return Task.FromResult(true);
        }

        public Task<bool> DeletePedidoAsync(int id)
        {
            var pedido = pedidos.FirstOrDefault(p => p.Id == id);
            if (pedido == null)
            {
                return Task.FromResult(false);
            }
            pedidos.Remove(pedido);
            return Task.FromResult(true);
        }
    }
}
