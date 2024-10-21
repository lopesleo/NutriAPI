using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NutrIA.Data;
using NutrIA.Models;
using NutrIA.Repositorios;
using NutrIA.Repositorios.Interfaces;

namespace NutrIA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteRepositorio _pacienteRepositorio;

        public PacienteController(IPacienteRepositorio pacienteRepositorio)
        {
            _pacienteRepositorio = pacienteRepositorio;
        }
        //get api/pacientes

        [HttpGet]
        public async Task<ActionResult<List<PacienteModel>>> ListarTodosPacientes()
        {

            List<PacienteModel> pacientes =  await _pacienteRepositorio.ListarTodosPacientes();
            return Ok(pacientes);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<PacienteModel>> BuscarPorId(int id)
        {

            PacienteModel paciente = await _pacienteRepositorio.BuscarPacientePorId(id);

            
            return Ok(paciente);
        }
        [HttpPost]
        public async Task<ActionResult<PacienteModel>> Cadastrar([FromBody] PacienteModel paciente)
        {
            

            PacienteModel _paciente = await _pacienteRepositorio.Adicionar(paciente);
            return Ok(_paciente);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<PacienteModel>> Atualizar([FromBody] PacienteModel paciente, int id)
        {
            if (paciente == null)
            {
                return BadRequest("Paciente não pode ser nulo.");
            }

            if (paciente.Id != id)
            {
                return BadRequest("ID do paciente não corresponde ao ID fornecido na URL.");
            }

            try
            {
                PacienteModel _paciente = await _pacienteRepositorio.Atualizar(paciente, id);
                return Ok(_paciente);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, "Erro ao atualizar o paciente. " + ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Apagar(int id)
        {
            bool resultado = await _pacienteRepositorio.Apagar(id);
            return Ok(resultado);
        }
    }

}
