using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class RestricaoDomain: BaseModel
    {
        public Guid ProjetoId { get; set; }
        public virtual ProjetoDomain Projeto { get; set; }

        public string DescricaoResumida { get; set; }
        public string Descricao { get; set; }

        public Guid CategoriaRestricaoId { get; set; }
        public virtual CategoriaRestricaoDomain CategoriaRestricao { get; set; }
        
    }
}