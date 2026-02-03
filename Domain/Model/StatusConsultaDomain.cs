using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class StatusConsultaDomain: BaseModel
    {
        public string Nome { get; set; }
        
    }

     public static class StatusConsultaIds
    {
        public static readonly Guid Agendada       = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa");
        public static readonly Guid Confirmada     = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb");
        public static readonly Guid EmAtendimento  = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc");
        public static readonly Guid Finalizada     = Guid.Parse("dddddddd-dddd-dddd-dddd-dddddddddddd");
        public static readonly Guid Cancelada      = Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee");
        public static readonly Guid NaoCompareceu  = Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffff");
    }
}