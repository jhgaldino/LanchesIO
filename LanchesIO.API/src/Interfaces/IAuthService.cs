using LanchesIO.API.src.Models;

namespace LanchesIO.API.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponse?> LoginAsync(string username, string password);
    }
}