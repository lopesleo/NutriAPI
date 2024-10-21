using NutrIA.Models;

namespace NutrIA.Repositorios.Interfaces
{
    public interface INutricionistaRepositorio
    {
        Task<NutricionistaModel> Cadastrar(NutricionistaModel nutricionista);
        Task<NutricionistaModel> BuscarPorId(int id);
        Task<NutricionistaModel> Atualizar(NutricionistaModel nutricionista, int id);
        Task<bool> Apagar(int id);
    }
}
