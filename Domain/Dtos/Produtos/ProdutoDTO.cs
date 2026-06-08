using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Model;

namespace Domain.Dtos.Produtos
{
    public class ProdutoDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public virtual UnidadeMedidaDomain UnidadeMedida { get; set; }
        public virtual FichaTecnica FichaTecnica { get; set; }
        public string CodigoBarra { get; set; }
        public bool Insumo { get; set; } = false; 
    }
}