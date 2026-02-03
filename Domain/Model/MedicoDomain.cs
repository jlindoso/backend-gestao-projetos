using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class MedicoDomain : BaseModel
    {
        public string Nome { get; set; }
        public Guid UsuarioId { get; set; }
        public virtual UsuarioDomain Usuario { get; set; }

        public string CRM { get; set; } = string.Empty;  // Registro profissional
        public string Especialidade { get; set; } = string.Empty;
    }
}