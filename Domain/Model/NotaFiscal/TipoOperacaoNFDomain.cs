using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Model.NotaFiscal
{
    public class TipoOperacaoNFDomain: BaseModel
    {
        public int Tipo { get; set; } // 0 - Entrada 1 - Saida
        public string Nome { get; set; } // Entrada/ Saida
        
    }
}