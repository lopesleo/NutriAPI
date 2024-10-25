using Microsoft.EntityFrameworkCore;
using NutrIA.Models;
using NutrIA.Repositorios.Interfaces;
using NutrIA.Services.Interfaces;

namespace NutrIA.Services
{

    public class NutricionistaService(INutricionistaRepositorio nutricionistaRepositorio, IPacienteRepositorio pacienteRepositorio) : INutricionistaService
    {
        private readonly INutricionistaRepositorio _nutricionistaRepositorio = nutricionistaRepositorio;
        private readonly IPacienteRepositorio _pacienteRepositorio = pacienteRepositorio;

        public async Task<List<Paciente>> ListarPacientesPorNutricionista(int nutricionistaId)
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
        public async Task<Paciente> AdicionarPaciente(int nutricionistaID, Paciente paciente)
        {
            _ = await _nutricionistaRepositorio.BuscarPorId(nutricionistaID) ?? throw new KeyNotFoundException($"Nutricionista com id {nutricionistaID} não encontrado.");
            paciente.NutricionistaId = nutricionistaID;
            await _pacienteRepositorio.Adicionar(paciente);
            return paciente;
        }

        public async Task<Nutricionista> Cadastrar(Nutricionista nutricionista)
        {
            try
            {
                await _nutricionistaRepositorio.Cadastrar(nutricionista);
                return nutricionista;
            }
            catch {
                throw;
            }
        }

        public async Task<Nutricionista> BuscarNutricionista(int id)
        {
            return await _nutricionistaRepositorio.BuscarPorId(id)
                   ?? throw new KeyNotFoundException($"Nutricionista com id {id} não encontrado.");
        }
        public async Task<Nutricionista> AtualizarNutricionista(Nutricionista nutricionista, int id)
        {
            if (nutricionista.Id != id)
            {
                throw new Exception($"O ID do nutricionista não corresponde ao ID fornecido na requisição.");
            }

            var nutricionistaExistente = await _nutricionistaRepositorio.BuscarPorId(id);

            if (nutricionistaExistente == null)
            {
                throw new KeyNotFoundException($"Nutricionista não encontrado.");
            }

            return await _nutricionistaRepositorio.Atualizar(nutricionista, id);
        }

        public async Task<bool?> ExcluirNutricionista(int id)
        {
            var nutricionista = await _nutricionistaRepositorio.BuscarPorId(id);

            if (nutricionista == null)
            {
                return null; // Nutricionista não encontrado
            }

            return await _nutricionistaRepositorio.Apagar(id);
        }

    }
}  
