using LanchesIO.API.src.Interfaces;
using LanchesIO.API.src.Models;

namespace LanchesIO.API.src.Services
{
    public class IngredienteService : IIngredienteService
    {
        private static List<Ingrediente> ingredientes = new List<Ingrediente>();

        public async Task<IEnumerable<Ingrediente>> GetIngredientesAsync()
        {
            await Task.Delay(100);
            return ingredientes;
        }

        public async Task<Ingrediente?> GetIngredienteAsync(int id)
        {
            await Task.Delay(100);
            return ingredientes.Find(i => i.Id == id);
        }

        public async Task<Ingrediente> CreateIngredienteAsync(Ingrediente ingrediente)
        {
            await Task.Delay(100);
            ingrediente.Id = ingredientes.Count > 0 ? ingredientes.Max(i => i.Id) + 1 : 1;
            ingredientes.Add(ingrediente);
            return ingrediente;
        }

        public async Task<bool> UpdateIngredienteAsync(int id, Ingrediente updatedIngrediente)
        {
            await Task.Delay(100);
            var ingrediente = ingredientes.Find(i => i.Id == id);
            if (ingrediente == null)
            {
                return false;
            }
            ingrediente.Nome = updatedIngrediente.Nome;
            ingrediente.Valor = updatedIngrediente.Valor;
            return true;
        }

        public async Task<bool> DeleteIngredienteAsync(int id)
        {
            await Task.Delay(100);
            var ingrediente = ingredientes.Find(i => i.Id == id);
            if (ingrediente == null)
            {
                return false;
            }
            ingredientes.Remove(ingrediente);
            return true;
        }
    }
}
