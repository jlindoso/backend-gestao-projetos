using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class JustificativaDomain: BaseModel
    {
        public Guid ProjetoId { get; set; }
        public virtual ProjetoDomain Projeto { get; set; }

        public string DescricaoResumida { get; set; }
        public string Descricao { get; set; }

        
        public Guid TipoJustificativaId { get; set; }
        public virtual TipoJustificativaDomain Tipo { get; set; }
        
    }
}