using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace NutrIA.Models
{
    public class Nutricionista
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome não pode ter mais de 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O email deve ser um endereço de email válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório.")]
        [Phone(ErrorMessage = "O telefone deve ser um número de telefone válido.")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O CRN é obrigatório.")]
        public string CRN { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        [DataType(DataType.Date, ErrorMessage = "A data de nascimento deve ser uma data válida.")]
        public DateTime DataNascimento { get; set; }

        public List<Paciente> Pacientes { get; set; } = new List<Paciente>();
    }
}
