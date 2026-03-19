using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Model.NotaFiscal
{
    public class IdentificacaoNFDomain: BaseModel
    {
        public int Numero { get; init; }
        public int Serie { get; init; }
        public DateTime DataEmissao { get; init; }
        public TipoOperacaoNFDomain TipoOperacao { get; init; } 
        public TipoEmissaoNFDomain TipoEmissao { get; init; }
    }
}