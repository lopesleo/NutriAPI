using NutrIA.Data;
using NutrIA.Models;
using NutrIA.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace NutrIA.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly ApplicationDbContext _context;

        public UsuarioService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Usuario usuario)
        {
            Console.WriteLine("Adicionando usuário ao contexto...");
            _context.Usuario.Add(usuario);
            Console.WriteLine("Salvando mudanças no banco...");
            var result = await _context.SaveChangesAsync();
            Console.WriteLine($"Linhas afetadas: {result}");
        }

        public async Task<Usuario> GetByEmailAsync(string email)
        {
            var usuario = await _context.Usuario.FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());
            Console.WriteLine($"Usuário encontrado para {email}: {usuario != null}");
            return usuario;
        }

        // Outros métodos
        public async Task<Usuario> GetUserByIdAsync(int id)
        {
            return await _context.Usuario.FindAsync(id);
        }

        public async Task<Usuario> RegisterUserAsync(string username, string password)
        {
            var usuario = new Usuario(username, username, password);
            await CreateAsync(usuario);
            return usuario;
        }

        public async Task<bool> AuthenticateUserAsync(string username, string password)
        {
            var usuario = await GetByEmailAsync(username);
            return usuario != null && usuario.VerificarSenha(password);
        }
    }
}