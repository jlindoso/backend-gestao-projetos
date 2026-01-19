using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class ProjetoDomain:BaseModel
    {
        public string Nome {get; set;}
        public string Objetivo {get; set;}
        public string Produto { get; set; }
        public string ObjetivoSmart {get; set;}
        public DateTime? DataInicio {get; set;} = null;
        public DateTime? DataTermino {get; set;} = null;
        public Guid StatusProjetoId { get; set; }
        public virtual StatusProjetoDomain StatusProjeto {get; set;}
    }
}