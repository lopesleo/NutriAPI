
using Newtonsoft.Json;

namespace NutrIA.Models.DTOs
{
    public class PacienteDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Altura { get; set; }
        public double Peso { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string Telefone { get; set; }
    }
}