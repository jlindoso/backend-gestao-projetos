using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Model.NotaFiscal
{
    public class TotalizadoresNFDomain: BaseModel
    {
   
        public decimal ValorTotalProdutos { get; init; }
        public decimal ValorTotalNota { get; init; }
        public decimal ValorTotalTributos { get; init; } 
    
    }
}