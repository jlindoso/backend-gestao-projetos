using System.ComponentModel.DataAnnotations;
using Domain.Model;
namespace Domain.Dtos.Produtos
{
    public class CreateProduto
    {
        [Required]
        public string Nome { get; set; }
        
        public Guid UnidadeMedidaId { get; set; } = UnidadesDeMedida.DEFAULT;

        [Required]
        public string CodigoBarra { get; set; }
        public int EstoqueMinimo { get; set; } = 10;
    }
}