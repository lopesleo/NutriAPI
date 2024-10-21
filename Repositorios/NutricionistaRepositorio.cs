using Microsoft.EntityFrameworkCore;
using NutrIA.Data;
using NutrIA.Models;
using NutrIA.Repositorios.Interfaces;

namespace NutrIA.Repositorios
{
    public class NutricionistaRepositorio : INutricionistaRepositorio
    {
        private readonly IPacienteRepositorio _pacienteRepositorio;
        private readonly ApplicationDbContext _context;
        public NutricionistaRepositorio(ApplicationDbContext dbContext, IPacienteRepositorio pacienteRepositorio)
        {
            _context = dbContext;
            _pacienteRepositorio = pacienteRepositorio;
        }

        public async Task<bool> Apagar(int id)
        {
            var nutricionistaPorID = await _context.Nutricionista.FindAsync(id) ?? throw new Exception($"Nutricionista id {id} não encontrado"); ;

            _context.Nutricionista.Remove(nutricionistaPorID);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<NutricionistaModel> BuscarPorId(int id)
        {
            var nutricionista = await _context.Nutricionista.FindAsync(id);
            return nutricionista ?? throw new Exception($"Nutricionista com id {id} não encontrado.");
        }
        public async Task<NutricionistaModel> Atualizar(NutricionistaModel nutricionista, int id)
        {
            var nutricionistaPorId = await _context.Nutricionista.FindAsync(id) ?? throw new Exception($"Nutricionista com id {id} não encontrado.");
            nutricionistaPorId.Nome = nutricionista.Nome;
            nutricionistaPorId.Email = nutricionista.Email;
            nutricionistaPorId.CPF = nutricionista.CPF;
            nutricionistaPorId.CRN = nutricionista.CRN;
            nutricionistaPorId.DataNascimento = nutricionista.DataNascimento;
            nutricionistaPorId.Pacientes = nutricionista.Pacientes;
            _context.Nutricionista.Update(nutricionistaPorId);
            await _context.SaveChangesAsync();
            return nutricionistaPorId;
        }

        public async Task<NutricionistaModel> Cadastrar(NutricionistaModel nutricionista)
        {
            _context.Add(nutricionista);
            await _context.SaveChangesAsync();
            return nutricionista;
        }

        public async Task<List<PacienteModel>> ListarPacientes(int nutricionistaID)
        {
            return await _pacienteRepositorio.BuscarPacientesPorNutricionista(nutricionistaID);
        }
      
    }
}
