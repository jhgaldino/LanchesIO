using LanchesIO.API.src.Models;

namespace LanchesIO.API.src.Interfaces
{
    public interface ILancheService
    {
        Task<IEnumerable<Lanche>> GetLanchesAsync();
        Task<Lanche> GetLancheAsync(int id);
        Task<Lanche> CreateLancheAsync(Lanche lanche);
        Task<bool> UpdateLancheAsync(int id, Lanche updatedLanche);
        Task<bool> DeleteLancheAsync(int id);
    }
}
