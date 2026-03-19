using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Model.NotaFiscal;

namespace Domain.Model.NotaFiscal
{
    public class NotaFiscalDomain: BaseModel
    {
        public string ChaveAcesso { get; init; } = string.Empty;
        public IdentificacaoNFDomain Identificacao { get; init; } = new();
        public EmitenteNFDomain Emitente { get; init; } = new();
        public DestinatarioEFDomain Destinatario { get; init; } = new();
        public IReadOnlyCollection<ItemNFDomain> Itens { get; init; } = new List<ItemNFDomain>();
        public TotalizadoresNFDomain Totais => CalcularTotais();

        private TotalizadoresNFDomain CalcularTotais()
        {
            
            return new TotalizadoresNFDomain()
            {
                ValorTotalProdutos = Itens.Sum(i => i.ValorTotal),
                ValorTotalNota = Itens.Sum(i => i.ValorTotal) 
            };
        }
    }
}