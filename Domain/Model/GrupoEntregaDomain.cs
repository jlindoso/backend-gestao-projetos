using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class GrupoEntregaDomain: BaseModel
    {

        public Guid ProjetoId { get; set; }
        public virtual ProjetoDomain Projeto { get; set; }

        public string DescricaoResumida { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicioPrevista { get; set; }
        public DateTime DataTerminoPrevista { get; set; }
        public decimal OrcamentoEstimado { get; set; }
        
    }
}