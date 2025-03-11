using NutrIA.Models;

namespace NutrIA.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<Usuario> GetUserByIdAsync(int id);
        Task<Usuario> RegisterUserAsync(string username, string password);
        Task<bool> AuthenticateUserAsync(string username, string password);
        Task<Usuario> GetByEmailAsync(string email); // Adicionado
        Task CreateAsync(Usuario usuario); // Adicionado
    }
}