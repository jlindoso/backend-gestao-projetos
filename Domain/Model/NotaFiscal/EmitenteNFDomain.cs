using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Model.NotaFiscal
{
    public class EmitenteNFDomain: BaseModel
    {
        public string Cnpj { get; init; } = string.Empty;
        public string RazaoSocial { get; init; } = string.Empty;
        public string InscricaoEstadual { get; init; } = string.Empty;
        public EnderecoNFDomain Endereco { get; init; } = new();
    }
}