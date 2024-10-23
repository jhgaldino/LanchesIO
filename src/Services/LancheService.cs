using LanchesIO.src.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanchesIO.src.Services
{
    public class LancheService
    {
        private static List<Lanche> lanches = new List<Lanche>();

        public Task<IEnumerable<Lanche>> GetLanchesAsync()
        {
            return Task.FromResult(lanches.AsEnumerable());
        }

        public Task<Lanche?> GetLancheByIdAsync(int id)
        {
            var lanche = lanches.FirstOrDefault(l => l.Id == id);
            return Task.FromResult(lanche);
        }

        public Task<Lanche> AddLancheAsync(Lanche lanche)
        {
            lanche.Validate();
            lanche.Id = lanches.Count > 0 ? lanches.Max(l => l.Id) + 1 : 1;
            lanches.Add(lanche);
            return Task.FromResult(lanche);
        }

        public Task<bool> UpdateLancheAsync(int id, Lanche updatedLanche)
        {
            var lanche = lanches.FirstOrDefault(l => l.Id == id);
            if (lanche == null)
            {
                return Task.FromResult(false);
            }

            updatedLanche.Validate();
            lanche.Nome = updatedLanche.Nome;
            lanche.Ingredientes = updatedLanche.Ingredientes;
            return Task.FromResult(true);
        }

        public Task<bool> DeleteLancheAsync(int id)
        {
            var lanche = lanches.FirstOrDefault(l => l.Id == id);
            if (lanche == null)
            {
                return Task.FromResult(false);
            }
            lanches.Remove(lanche);
            return Task.FromResult(true);
        }
    }
}
