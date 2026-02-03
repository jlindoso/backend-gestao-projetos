using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Dtos.Auth
{
    public class UsuarioLogadoDto
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}