using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class TipoConsultaDomain: BaseModel
    {
        public string Nome { get; set; }
    }

    public static class TipoConsultaIds
    {
        public static readonly Guid Consulta     = Guid.Parse("11111111-1111-1111-1111-111111111111");
        public static readonly Guid Retorno      = Guid.Parse("22222222-2222-2222-2222-222222222222");
        public static readonly Guid Procedimento = Guid.Parse("33333333-3333-3333-3333-333333333333");
    }
}