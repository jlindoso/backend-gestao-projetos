using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class EstoqueDomain: BaseModel
    {
        public Guid ProdutoId { get; set; }
        public virtual ProdutoDomain Produto { get; set; }
        public DateTime? DataValidade { get; set; }
        public string Lote { get; set; }
        public DateTime DataEntrada { get; set; } = DateTime.UtcNow;
        public int Quantidade { get; set; }
    }
}