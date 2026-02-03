using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class EnfermeiroDomain : BaseModel
    {

        public string Nome { get; set; }
        public Guid UsuarioId { get; set; }
        public virtual UsuarioDomain Usuario { get; set; }

        public string COREN { get; set; } = string.Empty;
    }
}