using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Domain.Model
{
    public class UsuarioDomain: IdentityUser<Guid>
    {
        public string CPF { get; set; } = string.Empty;

        public Guid? SexoId { get; set; }
        public virtual SexoDomain SexoBiologico { get; set; }


         public Guid? GeneroId { get; set; }
        public virtual SexoDomain Genero { get; set; }

        public string NomeSocial { get; set; }

    }
}