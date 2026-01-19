using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class RiscoDomain: BaseModel
    {
        
        public Guid ProjetoId { get; set; }
        public virtual ProjetoDomain Projeto { get; set; }

        public string DescricaoResumida { get; set; }
        public string Descricao { get; set; }

    
        public Guid CategoriaId { get; set; }
        public virtual CategoriaRiscoDomain Categoria { get; set; }

         public Guid ProbabilidadeId { get; set; }
        public ProbabilidadeRiscoDomain Probabilidade { get; set; }

         public Guid ImpactoId { get; set; }
        public ImpactoRiscoDomain Impacto { get; set; } 

        public string EstrategiaResposta { get; set; }

        
    }
}