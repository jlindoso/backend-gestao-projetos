using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class CategoriaProdutoDomain: BaseModel
    {
        public Guid ProdutoId { get; set; }
        public virtual ProdutoDomain Produto { get; set; }

        public Guid CategoriaId { get; set; }
        public virtual CategoriaDomain Categoria { get; set; }
        
    }
}