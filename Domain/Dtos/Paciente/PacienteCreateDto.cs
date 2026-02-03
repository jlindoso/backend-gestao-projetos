using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Dtos.Paciente
{
   public class PacienteCreateDto
    {
        // Campos do IdentityUser
        public string Nome { get; set; }
        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Email inválido.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "O nome de usuário é obrigatório.")]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [MinLength(6, ErrorMessage = "A senha deve ter no mínimo 6 caracteres.")]
        public string Password { get; set; } = string.Empty;

        // Campos do paciente
        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve ter 11 dígitos.")]
        public string CPF { get; set; } = string.Empty;

        [Required(ErrorMessage = "O Nome Social é obrigatório.")]
        public string NomeSocial { get; set; } = string.Empty;

        public Guid? SexoId { get; set; }      // Opcional
        public Guid? GeneroId { get; set; }    // Opcional
        public DateTime DataNascimento { get; set; }
        public string PlanoSaude { get; set; }
    }
}