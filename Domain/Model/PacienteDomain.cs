using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class PacienteDomain : BaseModel
    {

        public string Nome { get; set; } = string.Empty;
        public string RG { get; set; } = string.Empty;
        public string Emissor { get; set; } = string.Empty;
        public string UF { get; set; } = string.Empty;
        public Guid UsuarioId { get; set; }
        public virtual UsuarioDomain Usuario { get; set; }

        public string NumeroPlanoSaude { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}