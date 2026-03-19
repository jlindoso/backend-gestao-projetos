using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Model.NotaFiscal
{
    public class ItemNFDomain: BaseModel
    {
        public int NumeroItem { get; init; }
        public ProdutoDomain Produto { get; init; } = new();
        public decimal Quantidade { get; init; }
        public decimal ValorUnitario { get; init; }
        public decimal ValorTotal => Quantidade * ValorUnitario;
        
        // public Impostos Impostos { get; init; } = new();
    }
}