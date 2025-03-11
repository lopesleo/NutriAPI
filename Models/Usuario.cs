using System;
using System.ComponentModel.DataAnnotations;

namespace NutrIA.Models
{
    /// <summary>
    /// Representa o usuário responsável pela autenticação.
    /// </summary>
    public class Usuario
    {
        /// <summary>
        /// Identificador único do usuário.
        /// </summary>
        [Key]
        public int Id { get; set; } // Setter público para o EF

        /// <summary>
        /// Nome completo do usuário.
        /// </summary>
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome não pode ter mais de 100 caracteres.")]
        public string Nome { get; set; }

        /// <summary>
        /// Email do usuário. Idealmente, deve ser único.
        /// </summary>
        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O email deve ser válido.")]
        public string Email { get; set; }

        /// <summary>
        /// Hash da senha do usuário (utilizando BCrypt).
        /// </summary>
        [Required(ErrorMessage = "A senha é obrigatória.")]
        public string SenhaHash { get; private set; }

        /// <summary>
        /// Construtor sem parâmetros para uso pelo Entity Framework.
        /// </summary>
        public Usuario() { }

        /// <summary>
        /// Construtor para criação de um novo usuário.
        /// </summary>
        /// <param name="nome">Nome do usuário.</param>
        /// <param name="email">Email do usuário.</param>
        /// <param name="senha">Senha em texto puro (será validada e convertida para hash).</param>
        public Usuario(string nome, string email, string senha)
        {
            Nome = nome;
            Email = email;
            AlterarSenha(senha);
        }

        /// <summary>
        /// Altera a senha do usuário, validando os critérios de segurança e gerando o hash.
        /// </summary>
        /// <param name="senha">Senha em texto puro.</param>
        /// <exception cref="ArgumentException">Lançada se a senha não atender aos critérios de segurança.</exception>
        public void AlterarSenha(string senha)
        {
            if (!ValidarSenha(senha))
                throw new ArgumentException("Senha não atende aos critérios de segurança.");

            // O work factor 13 é um bom equilíbrio entre segurança e performance,
            // mas pode ser ajustado conforme a necessidade do ambiente de produção.
            SenhaHash = BCrypt.Net.BCrypt.EnhancedHashPassword(senha, 13);
        }

        /// <summary>
        /// Verifica se a senha informada corresponde ao hash armazenado.
        /// </summary>
        /// <param name="senha">Senha em texto puro.</param>
        /// <returns>Verdadeiro se a senha for válida, caso contrário, falso.</returns>
        public bool VerificarSenha(string senha)
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(senha, SenhaHash);
        }

        /// <summary>
        /// Valida os critérios de segurança da senha.
        /// A senha deve ter pelo menos 8 caracteres, conter uma letra maiúscula, uma minúscula, um dígito e um caractere especial.
        /// </summary>
        /// <param name="senha">Senha em texto puro.</param>
        /// <returns>Verdadeiro se a senha atender aos critérios; caso contrário, falso.</returns>
        private bool ValidarSenha(string senha)
        {
            if (string.IsNullOrWhiteSpace(senha) || senha.Length < 8)
                return false;

            return senha.Any(char.IsUpper) &&
                   senha.Any(char.IsLower) &&
                   senha.Any(char.IsDigit) &&
                   senha.Any(ch => !char.IsLetterOrDigit(ch));
        }
    }
}
