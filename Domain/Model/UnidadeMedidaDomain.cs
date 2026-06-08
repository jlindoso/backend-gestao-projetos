using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class UnidadeMedidaDomain: BaseModel
    {
        public string Nome { get; set; }
        public string Sigla { get; set; }
        
        
    }


    public static class UnidadesDeMedida
    {
        public static Guid DEFAULT = Guid.Parse("2700cf0d-3757-4869-b730-afa9ee7fb89f");
    }
    
}