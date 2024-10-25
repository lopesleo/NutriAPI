using NutrIA.Models;

namespace NutrIA.Services.Interfaces
{
    public interface INutricionistaService
    {
        Task<List<Paciente>> ListarPacientesPorNutricionista(int idNutricionista);
        Task<Nutricionista> Cadastrar(Nutricionista nutricionista);
        Task<Paciente> AdicionarPaciente(int nutricionistaID, Paciente paciente);
        Task<Nutricionista> BuscarNutricionista(int id);
        Task<Nutricionista> AtualizarNutricionista(Nutricionista nutricionista, int id);
        Task<bool?> ExcluirNutricionista(int id);

    }
}
