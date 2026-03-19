using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Model.NotaFiscal
{
    public class EnderecoNFDomain: BaseModel
    {
        public string Logradouro { get; init; } = string.Empty;
        public string Numero { get; init; } = string.Empty;
        public string Bairro { get; init; } = string.Empty;
        public string CodigoIbgeMunicipio { get; init; } = string.Empty;
        public string Uf { get; init; } = "AM";
    }
}