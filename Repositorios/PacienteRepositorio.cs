using Microsoft.EntityFrameworkCore;
using NutrIA.Data;
using NutrIA.Models;
using NutrIA.Repositorios.Interfaces;

namespace NutrIA.Repositorios
{
    public class PacienteRepositorio : IPacienteRepositorio
    {
        private readonly ApplicationDbContext _context;

        public PacienteRepositorio(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task<List<PacienteModel>> ListarTodosPacientes()
        {
            return await _context.Paciente.ToListAsync();
        }

        public async Task<List<PacienteModel>> BuscarPacientesPorNutricionista (int nutricionistaID)
        {
            return await _context.Paciente.Where(p => p.NutricionistaId == nutricionistaID).ToListAsync();
        }

        public async Task<PacienteModel> BuscarPacientePorId(int id)
        {
            return await _context.Paciente.FirstOrDefaultAsync(p => p.Id == id);
        }



        public async Task<PacienteModel> Adicionar(PacienteModel paciente)
        {
            _context.Paciente.Add(paciente);
           await _context.SaveChangesAsync();
            return paciente;
        }

        public async Task<bool> Apagar(int id)
        {
            var pacientePorID = await BuscarPacientePorId(id) ?? throw new Exception($"Paciente id {id} não encontrado"); ;

            _context.Paciente.Remove(pacientePorID);
            await _context.SaveChangesAsync();
            return true;
        }

    
        public async Task<PacienteModel> Atualizar(PacienteModel paciente, int id)
        {
            var pacientePorID = await BuscarPacientePorId(id) ?? throw new Exception($"Paciente id {id} não encontrado"); ;

            
            pacientePorID.Nome = paciente.Nome;
            pacientePorID.Altura = paciente.Altura;
            pacientePorID.Peso = paciente.Peso;
            pacientePorID.Email = paciente.Email;
            pacientePorID.DataNascimento = paciente.DataNascimento;
            pacientePorID.Sexo = paciente.Sexo;
            pacientePorID.RestricoesAlimentares = paciente.RestricoesAlimentares;
            pacientePorID.Telefone = paciente.Telefone;
            pacientePorID.Notas = paciente.Notas;
            
            _context.Update(pacientePorID);
            await _context.SaveChangesAsync();

            return pacientePorID;
        }

     
    }
}
