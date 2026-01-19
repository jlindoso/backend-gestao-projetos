using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class UsuarioEnvolvidoDomain: BaseModel
    {
        public Guid ProjetoId { get; set; }
        public virtual ProjetoDomain Projeto { get; set; }


        public Guid TipoEnvolvimentoId { get; set; }
        public virtual TipoUsuarioEnvolvido Tipo { get; set; }
        

        // public Guid UsuarioId { get; set; }
        // public virtual UsuarioDomain Usuario { get; set; }

    }
}