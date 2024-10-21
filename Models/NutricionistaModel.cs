using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace NutrIA.Models
{
    public class NutricionistaModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string Telefone { get; set; }

        [Required]
        public string CRN { get; set; }
        [Required]
        public string CPF { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [JsonIgnore]
        public List<PacienteModel> Pacientes { get; set; } = new List<PacienteModel>();
    }
}
