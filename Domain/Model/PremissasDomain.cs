using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class PremissasDomain: BaseModel
    {
        public Guid ProjetoId { get; set; }
        public virtual ProjetoDomain Projeto { get; set; }

        public string DescricaoResumida { get; set; }
        public string Descricao { get; set; }
        public bool Validada { get; set; } = false;
       
        public string ImpactorResumido { get; set; }
        public string Impacto { get; set; }
        
    }
}