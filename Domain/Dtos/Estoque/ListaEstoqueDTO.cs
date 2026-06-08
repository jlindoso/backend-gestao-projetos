using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Dtos.Estoque
{
    public class EstoqueDTO
    {
        
        public Guid ProdutoId { get; set; }
        public string ProdutoNome { get; set; }
        public string CodigoBarra { get; set; }
        public int QuantidadeAtual { get; set; }
        public int QuantidadeMinima { get; set; }
        public bool Insumo { get; set; }
    }
}