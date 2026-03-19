using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class MovimentacaoEstoqueDomain: BaseModel
    {
        public Guid ProdutoId { get; set; }
        public virtual ProdutoDomain Produto { get; set; }

        public int Quantidade { get; set; }

        public DateTime DataSaida  { get; set; }

        public Guid TipoSaidaId { get; set; }
        public virtual TipoSaidaDomain TipoSaida { get; set; }
    }
}