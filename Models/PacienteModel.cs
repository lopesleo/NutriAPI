using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace NutrIA.Models
{
    public class PacienteModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public required string Nome { get; set; }
        [Required]
        [Range(0, 3.0)]
        public required double Altura { get; set; }

        [Required]
        [Range(0, 500)]
        public double Peso { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        public required string Sexo { get; set; }

        [Phone]
        public required string Telefone { get; set; }

        public string? RestricoesAlimentares { get; set; }
        public string? Notas { get; set; }

        public int? NutricionistaId { get; set; } // ID do nutricionista
        [JsonIgnore]
        public NutricionistaModel? Nutricionista { get; set; } // Navegação para o nutricionista

        [NotMapped]
        public int Idade
        {
            get
            {
                return DateTime.Now.Year - DataNascimento.Year -
                       (DateTime.Now.DayOfYear < DataNascimento.DayOfYear ? 1 : 0);
            }
        }


    }
}
