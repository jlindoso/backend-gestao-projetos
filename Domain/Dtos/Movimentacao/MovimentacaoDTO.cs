using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Dtos.Movimentacao
{
    public class MovimentacaoDTO
    {
        public Guid ProdutoId { get; set; }

        public int Quantidade { get; set; }

        public DateTime DataSaida  { get; set; } = DateTime.UtcNow;

        public Guid TipoSaidaId { get; set; }
       
    }
}