using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Dtos;
using Domain.Dtos.Produtos;
using Domain.Model;

namespace Domain.Ports
{
    public interface IProdutoService: IService<ProdutoDomain>
    {
       Task<Response<ProdutoDomain>> AdicionarAsync(CreateProduto dto);


       Task<Response<ProdutoDomain>> ObterPorCodigoDeBarrasAsync(string codigoBarras);



       Task<ListResponse<ProdutoDTO>> Listar(string? nome, int page, int pageSize);
    }
}