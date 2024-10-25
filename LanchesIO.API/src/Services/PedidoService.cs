using LanchesIO.API.src.Interfaces;
using LanchesIO.API.src.Models;

namespace LanchesIO.API.src.Services
{
    public class PedidoService : IPedidoService
    {
        private static List<Pedido> pedidos = new List<Pedido>();

        public async Task<IEnumerable<Pedido>> GetPedidosAsync()
        {
            await Task.Delay(100);
            return pedidos;
        }

        public async Task<Pedido> GetPedidoAsync(int id)
        {
            await Task.Delay(100);
            return pedidos.Find(p => p.Id == id) ?? new Pedido();
        }

        public async Task<Pedido> CreatePedidoAsync(Pedido pedido)
        {
            await Task.Delay(100);
            pedido.Id = pedidos.Count > 0 ? pedidos.Max(p => p.Id) + 1 : 1;
            pedido.ValorTotal = CalcularValorTotal(pedido);
            pedidos.Add(pedido);
            return pedido;
        }

        public async Task<bool> UpdatePedidoAsync(int id, Pedido updatedPedido)
        {
            await Task.Delay(100);
            var pedido = pedidos.Find(p => p.Id == id);
            if (pedido == null)
            {
                return false;
            }
            pedido.Lanches = updatedPedido.Lanches;
            pedido.ValorTotal = CalcularValorTotal(updatedPedido);
            return true;
        }

        public async Task<bool> DeletePedidoAsync(int id)
        {
            await Task.Delay(100);
            var pedido = pedidos.Find(p => p.Id == id);
            if (pedido == null)
            {
                return false;
            }
            pedidos.Remove(pedido);
            return true;
        }

        private static decimal CalcularValorTotal(Pedido pedido)
        {
            decimal total = pedido.Lanches.Sum(l => l.Valor);
            int quantidadeLanches = pedido.Lanches.Count;

            if (quantidadeLanches >= 5)
            {
                total *= 0.90m; // 10% de desconto
            }
            else if (quantidadeLanches == 3)
            {
                total *= 0.95m; // 5% de desconto
            }
            else if (quantidadeLanches == 2)
            {
                total *= 0.97m; // 3% de desconto
            }

            return total;
        }
    }
}
