using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class FichaTecnicaItems: BaseModel
    {

        public Guid FichaTecnicaId { get; set; }
        public virtual FichaTecnica FichaTecnica { get; set; }

        public Guid ProdutoId { get; set; }
        public virtual ProdutoDomain Produto { get; set; }

        public decimal Quantidade { get; set; }

        public Guid UnidadeMedidaId { get; set; }
        public virtual UnidadeMedidaDomain UnidadeMedida { get; set; }
        
    }
}