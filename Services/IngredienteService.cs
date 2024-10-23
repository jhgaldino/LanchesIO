using LanchesIO.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace LanchesIO.Services
{
    public class IngredienteService
    {
        private static List<Ingrediente> ingredientes = new List<Ingrediente>();

        public Task<IEnumerable<Ingrediente>> GetIngredientesAsync()
        {
            return Task.FromResult(ingredientes.AsEnumerable());
        }

        public Task<Ingrediente> GetIngredienteByIdAsync(int id)
        {
            var ingrediente = ingredientes.FirstOrDefault(i => i.Id == id);
            return Task.FromResult(ingrediente);
        }

        public Task<Ingrediente> AddIngredienteAsync(Ingrediente ingrediente)
        {
            ingrediente.Id = ingredientes.Count > 0 ? ingredientes.Max(i => i.Id) + 1 : 1;
            ingredientes.Add(ingrediente);
            return Task.FromResult(ingrediente);
        }

        public Task<bool> UpdateIngredienteAsync(int id, Ingrediente updatedIngrediente)
        {
            var ingrediente = ingredientes.FirstOrDefault(i => i.Id == id);
            if (ingrediente == null)
            {
                return Task.FromResult(false);
            }
            ingrediente.Nome = updatedIngrediente.Nome;
            ingrediente.Valor = updatedIngrediente.Valor;
            return Task.FromResult(true);
        }

        public Task<bool> DeleteIngredienteAsync(int id)
        {
            var ingrediente = ingredientes.FirstOrDefault(i => i.Id == id);
            if (ingrediente == null)
            {
                return Task.FromResult(false);
            }
            ingredientes.Remove(ingrediente);
            return Task.FromResult(true);
        }
    }
}
