using Microsoft.EntityFrameworkCore;
using NutrIA.Models;
using NutrIA.Repositorios.Interfaces;

namespace NutrIA.Services
{

    public class NutricionistaService
    {
        private readonly INutricionistaRepositorio _nutricionistaRepositorio;
        private readonly IPacienteRepositorio _pacienteRepositorio;

        public NutricionistaService(INutricionistaRepositorio nutricionistaRepositorio, IPacienteRepositorio pacienteRepositorio)
        {
            _nutricionistaRepositorio = nutricionistaRepositorio;
            _pacienteRepositorio = pacienteRepositorio;
        }

        public async Task<List<PacienteModel>> ListarPacientesPorNutricionista(int nutricionistaId)
        {
            // Verifica se o nutricionista existe
            var nutricionista = await _nutricionistaRepositorio.BuscarPorId(nutricionistaId);
            if (nutricionista == null)
            {
                throw new Exception($"Nutricionista com id {nutricionistaId} não encontrado.");
            }

            // Busca pacientes pelo ID do nutricionista
            return await _pacienteRepositorio.BuscarPacientesPorNutricionista(nutricionistaId);
        }
        public async Task<PacienteModel> AdicionarPaciente(int nutricionistaID, PacienteModel paciente)
        {
            var nutricionista = await _nutricionistaRepositorio.BuscarPorId(nutricionistaID) ?? throw new Exception($"Nutricionista com id {nutricionistaID} não encontrado.");
            paciente.NutricionistaId = nutricionistaID;
            await _pacienteRepositorio.Adicionar (paciente);
            return paciente;
        }
    }
}
