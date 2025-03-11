using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NutrIA.Models;
using NutrIA.Services;
using NutrIA.Services.Interfaces;
using NutriAPI.Services;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using NutrIA.Models.DTOs;
namespace NutrIA.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly TokenService _tokenService;

        public AuthController(IUsuarioService usuarioService, TokenService tokenService)
        {
            _usuarioService = usuarioService;
            _tokenService = tokenService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingUser = await _usuarioService.GetByEmailAsync(model.Email);
            if (existingUser != null)
                return BadRequest(new { message = "Email já cadastrado." });

            try
            {
                var usuario = new Usuario(model.Nome, model.Email, model.Password);
                await _usuarioService.CreateAsync(usuario);
                return Ok(new { message = "Usuário criado com sucesso." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro ao criar usuário.", details = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var usuario = await _usuarioService.GetByEmailAsync(model.Email);
            if (usuario == null || !usuario.VerificarSenha(model.Password))
                return Unauthorized(new { message = "Email ou senha inválidos." });

            var claims = new[]
            {
        new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
        new Claim(ClaimTypes.Email, usuario.Email),
        new Claim(ClaimTypes.Name, usuario.Nome)
    };

            var token = _tokenService.GenerateToken(claims);
            return Ok(new { token });
        }
    }
}