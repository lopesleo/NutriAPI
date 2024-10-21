using NutrIA.Models;

namespace NutrIA.Repositorios.Interfaces
{
    public interface IPacienteRepositorio
    {
        Task<List<PacienteModel>> ListarTodosPacientes();
        Task<PacienteModel> BuscarPacientePorId(int id);
        Task<List<PacienteModel>> BuscarPacientesPorNutricionista (int nutricionistaID);
        Task<PacienteModel> Adicionar(PacienteModel paciente);
        Task<PacienteModel> Atualizar(PacienteModel paciente,int id);
        Task<bool> Apagar(int id);

    }
}
