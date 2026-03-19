using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Model.NotaFiscal
{
    public class TipoEmissaoNFDomain: BaseModel
    {
        public int Tipo { get; set; } // Normal = 1, ContingenciaOffline = 9
        public string Nome { get; set; } // Normal / ContingenciaOffline
        
    }
}