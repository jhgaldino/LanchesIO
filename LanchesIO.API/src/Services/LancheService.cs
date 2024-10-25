using LanchesIO.API.src.Interfaces;
using LanchesIO.API.src.Models;

namespace LanchesIO.API.src.Services
{
    public class LancheService : ILancheService
    {
        private static List<Lanche> lanches = new List<Lanche>();

        public async Task<IEnumerable<Lanche>> GetLanchesAsync()
        {
            await Task.Delay(100);
            return lanches;
        }

        public async Task<Lanche> GetLancheAsync(int id)
        {
            await Task.Delay(100);
            return lanches.Find(l => l.Id == id) ?? throw new KeyNotFoundException("Lanche not found");
        }

        public async Task<Lanche> CreateLancheAsync(Lanche lanche)
        {
            await Task.Delay(100);
            lanche.Id = lanches.Count > 0 ? lanches.Max(l => l.Id) + 1 : 1;
            lanches.Add(lanche);
            return lanche;
        }

        public async Task<bool> UpdateLancheAsync(int id, Lanche updatedLanche)
        {
            await Task.Delay(100);
            var lanche = lanches.Find(l => l.Id == id);
            if (lanche == null)
            {
                return false;
            }
            lanche.Nome = updatedLanche.Nome;
            lanche.Ingredientes = updatedLanche.Ingredientes;
            return true;
        }

        public async Task<bool> DeleteLancheAsync(int id)
        {
            await Task.Delay(100);
            var lanche = lanches.Find(l => l.Id == id);
            if (lanche == null)
            {
                return false;
            }
            lanches.Remove(lanche);
            return true;
        }
    }
}
