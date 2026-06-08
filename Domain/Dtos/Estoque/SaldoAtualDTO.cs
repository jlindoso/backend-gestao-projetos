using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Model;

namespace Domain.Dtos.Estoque
{
    public class SaldoAtualDTO
    {
        public List<EstoqueDomain> Estoques { get; set; }
        public int Total { get; set; }
        public decimal ValorTotal { get; set; }
    }
}