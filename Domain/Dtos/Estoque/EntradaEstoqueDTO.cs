using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Dtos.Estoque
{
    public class EntradaEstoqueDTO
    {
        [Required]
        public string CodigoBarras { get; set; }
        public DateTime? DataValidade { get; set; }
        public string Lote { get; set; }
        [Required]
        public int Quantidade { get; set; }
        [Required]
        public decimal ValorUnitario { get; set; }
    }
}