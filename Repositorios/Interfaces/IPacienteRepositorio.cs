using NutrIA.Models;

namespace NutrIA.Repositorios.Interfaces
{
    public interface IPacienteRepositorio
    {
        Task<List<Paciente>> ListarTodosPacientes();
        Task<Paciente> BuscarPacientePorId(int id);
        Task<List<Paciente>> BuscarPacientesPorNutricionista (int nutricionistaID);
        Task<Paciente> Adicionar(Paciente paciente);
        Task<Paciente> Atualizar(Paciente paciente,int id);
        Task<bool> Apagar(int id);

    }
}
