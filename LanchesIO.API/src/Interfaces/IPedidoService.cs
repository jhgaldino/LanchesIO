using LanchesIO.API.src.Models;

namespace LanchesIO.API.src.Interfaces
{
    public interface IPedidoService
    {
        Task<IEnumerable<Pedido>> GetPedidosAsync();
        Task<Pedido> GetPedidoAsync(int id);
        Task<Pedido> CreatePedidoAsync(Pedido pedido);
        Task<bool> UpdatePedidoAsync(int id, Pedido updatedPedido);
        Task<bool> DeletePedidoAsync(int id);
    }
}
