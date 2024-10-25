
namespace NutrIA.Models.DTOs
{
    public class NutricionistaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Crn { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}