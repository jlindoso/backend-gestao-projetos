using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Model.NotaFiscal
{
    public class DestinatarioEFDomain: BaseModel
    {
        public string CpfCnpj { get; init; } = string.Empty;
        public string Nome { get; init; } = string.Empty;
        public bool IsConsumidorFinal { get; init; } = true;
    }
}