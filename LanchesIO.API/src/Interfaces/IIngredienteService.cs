using LanchesIO.API.src.Models;

namespace LanchesIO.API.src.Interfaces
{
    public interface IIngredienteService
    {
        Task<IEnumerable<Ingrediente>> GetIngredientesAsync();
        Task<Ingrediente?> GetIngredienteAsync(int id);
        Task<Ingrediente> CreateIngredienteAsync(Ingrediente ingrediente);
        Task<bool> UpdateIngredienteAsync(int id, Ingrediente updatedIngrediente);
        Task<bool> DeleteIngredienteAsync(int id);
    }
}
