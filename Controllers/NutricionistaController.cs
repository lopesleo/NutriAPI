using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NutrIA.Data;
using NutrIA.Models;
using NutrIA.Repositorios;
using NutrIA.Repositorios.Interfaces;
using NutrIA.Services;

namespace NutrIA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NutricionistaController : ControllerBase
    {
        private readonly NutricionistaService _nutricionistaService;
        private readonly INutricionistaRepositorio _nutricionistaRepositorio;
        public NutricionistaController(NutricionistaService nutricionistaService, INutricionistaRepositorio nutricionistaRepositorio)
        {
            _nutricionistaService = nutricionistaService;
            _nutricionistaRepositorio = nutricionistaRepositorio;
        }

        [HttpGet("{id}/listar-pacientes")]
        public async Task<ActionResult<List<PacienteModel>>> ListarPacientes(int id)
        {
            try
            {
                var pacientes = await _nutricionistaService.ListarPacientesPorNutricionista(id);
                if (pacientes == null || pacientes.Count == 0)
                {
                    return NotFound($"Nenhum paciente encontrado para o nutricionista com id {id}.");
                }

                return Ok(pacientes);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao listar pacientes: {ex.Message}");
            }
        }
        [HttpPost("cadastrar")]
        public async Task<ActionResult<NutricionistaModel>> CadastrarNutricionista(NutricionistaModel nutricionistaModel)
        {
            await _nutricionistaRepositorio.Cadastrar(nutricionistaModel);
            return nutricionistaModel;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<NutricionistaModel>> ListarNutricionistas(int id)
        {
            var nutricionista = await _nutricionistaRepositorio.BuscarPorId(id);
            return Ok(nutricionista);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<NutricionistaModel>> AtualizarNutricionista(NutricionistaModel nutricionistaModel, int id)
        {
            var nutricionista = await _nutricionistaRepositorio.Atualizar(nutricionistaModel, id);
            return Ok(nutricionista);
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> ExcluirNutricionita(int id)
        {
            if(await _nutricionistaRepositorio.Apagar(id))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }

}
