using NutrIA.Models;

namespace NutrIA.Repositorios.Interfaces
{
    public interface INutricionistaRepositorio
    {
        Task<Nutricionista> Cadastrar(Nutricionista nutricionista);
        Task<Nutricionista> BuscarPorId(int id);
        Task<Nutricionista> Atualizar(Nutricionista nutricionista, int id);
        Task<bool> Apagar(int id);
    }
}
