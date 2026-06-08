using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class FichaTecnica: BaseModel
    {
        public string Nome { get; set; }

        public Guid ProdutoId { get; set; }
        public virtual ProdutoDomain Produto { get; set; }

        public Guid UnidadeMedidaId { get; set; }
        public virtual UnidadeMedidaDomain UnidadeMedida { get; set; }


        public string ModoPreparo { get; set; }

        public int TempoMedio { get; set; }
    }
}