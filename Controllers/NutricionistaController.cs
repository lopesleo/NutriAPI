using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NutrIA.Data;
using NutrIA.Models;
using NutrIA.Models.DTOs;
using NutrIA.Repositorios;
using NutrIA.Repositorios.Interfaces;
using NutrIA.Services;
using NutrIA.Services.Interfaces;

namespace NutrIA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NutricionistaController(INutricionistaService nutricionistaService, IMapper mapper) : ControllerBase
    {
        private readonly INutricionistaService _nutricionistaService = nutricionistaService;
        private readonly IMapper _mapper = mapper;

        [HttpGet("{id}/listar-pacientes")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Paciente>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]


        public async Task<ActionResult<List<Paciente>>> ListarPacientes(int id)
        {
            try
            {
                var pacientes = await _nutricionistaService.ListarPacientesPorNutricionista(id);
                if (pacientes == null || pacientes.Count == 0)
                {
                    return NotFound($"Nenhum paciente encontrado para o nutricionista com id {id}.");
                }
               var pacientesDTo =  _mapper.Map<List<PacienteDto>>(pacientes);
                return Ok(pacientesDTo);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao listar pacientes: {ex.Message}");
            }
        }
        [HttpPost("cadastrar")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Nutricionista))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Nutricionista>> CadastrarNutricionista(Nutricionista nutricionistaModel)
        {
            try
            {
                if (!ModelState.IsValid) 
                {
                    return BadRequest("Dados inválidos fornecidos.");
                }

                var novoNutricionista = await _nutricionistaService.Cadastrar(nutricionistaModel);
                return CreatedAtAction(nameof(CadastrarNutricionista), new { id = novoNutricionista.Id }, novoNutricionista);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound($"Erro ao cadastrar nutricionista: {ex.Message}");
            }
            catch (Exception ex) // Para erros inesperados
            {
                // Loga a exceção se necessário
                return StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um erro inesperado: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Nutricionista))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Nutricionista>> BuscarNutricionista(int id)
        {
            try
            {
                var nutricionista = await _nutricionistaService.BuscarNutricionista(id);
                return Ok(nutricionista);
            }
            catch(KeyNotFoundException ex)
            {
                return NotFound($"Nutricionista não encontrado: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao buscar nutricionista: {ex.Message}");
            }

        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Nutricionista))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Nutricionista>> AtualizarNutricionista(Nutricionista nutricionistaModel, int id)
        {
            var resultado = await _nutricionistaService.AtualizarNutricionista(nutricionistaModel, id);

            if (resultado == null)
            {
                return NotFound("Nutricionista não encontrado.");
            }

            return Ok(resultado);
        }


        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> ExcluirNutricionista(int id)
        {
            bool? resultado = await _nutricionistaService.ExcluirNutricionista(id);

            if (resultado == null)
            {
                return NotFound("Nutricionista não encontrado.");
            }

            if (resultado == true)
            {
                return Ok("Nutricionista excluído com sucesso.");
            }

            return BadRequest("Falha ao excluir o nutricionista.");
        }


    }

}
