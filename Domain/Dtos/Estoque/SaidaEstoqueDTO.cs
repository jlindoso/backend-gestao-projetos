using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Dtos.Estoque
{
    public class SaidaEstoqueDTO
    {
        [Required]
        public string CodigoBarras { get; set; }

        [Required]
        public int Quantidade { get; set; }
    }
}