using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class ProdutoDomain: BaseModel
    {
        public string Nome { get; set; }
        public Guid UnidadeMedidaId { get; set; }
        public virtual UnidadeMedidaDomain UnidadeMedida { get; set; }
        public string CodigoBarra { get; set; }
        public int EstoqueMinimo { get; set; }
        
    }
}