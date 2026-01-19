using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class RequisitoDomain: BaseModel
    {
        
        public Guid ProjetoId { get; set; }
        public virtual ProjetoDomain Projeto { get; set; }

        public string DescricaoResumida { get; set; }
        public string Descricao { get; set; }
        public Guid CategoriaId { get; set; }
        public virtual CategoriaRequisitoDomain Categoria { get; set; }
         public Guid PrioridadeId { get; set; }
        public virtual PrioridadeRequisitoDomain Prioridade { get; set; }
        public string CriterioAceitacao { get; set; }
        
    }
}