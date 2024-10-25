using AutoMapper;
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
    public class PacienteController(IPacienteRepositorio pacienteRepositorio) : ControllerBase
    {
        private readonly IPacienteRepositorio _pacienteRepositorio = pacienteRepositorio;
        
        //get api/pacientes

        [HttpGet]
        public async Task<ActionResult<List<Paciente>>> ListarTodosPacientes()
        {

            List<Paciente> pacientes =  await _pacienteRepositorio.ListarTodosPacientes();
            return Ok(pacientes);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Paciente>> BuscarPorId(int id)
        {

            Paciente paciente = await _pacienteRepositorio.BuscarPacientePorId(id);

            
            return Ok(paciente);
        }
        [HttpPost]
        public async Task<ActionResult<Paciente>> Cadastrar([FromBody] Paciente paciente)
        {
            

            Paciente _paciente = await _pacienteRepositorio.Adicionar(paciente);
            return Ok(_paciente);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Paciente>> Atualizar([FromBody] Paciente paciente, int id)
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
                Paciente _paciente = await _pacienteRepositorio.Atualizar(paciente, id);
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
