using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class TipoMovimentacaoDomain: BaseModel
    {
        public string Nome { get; set; }
    }


    public static class TiposDeMovimentacao
    {
        public static Guid ENTRADA = Guid.Parse("00000000-0000-0000-0000-000000000001");
        public static Guid SAIDA = Guid.Parse("00000000-0000-0000-0000-000000000002");
        public static Guid DEVOLUCAO = Guid.Parse("00000000-0000-0000-0000-000000000003"); 
        public static Guid DESCARTE = Guid.Parse("00000000-0000-0000-0000-000000000004"); 
        public static Guid CORTESIA = Guid.Parse("00000000-0000-0000-0000-000000000005"); 

        private static readonly HashSet<Guid> _todos = new() { ENTRADA, SAIDA, DEVOLUCAO, DESCARTE, CORTESIA };

        public static bool Existe(Guid id) => _todos.Contains(id);
    }
}