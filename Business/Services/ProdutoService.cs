using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Dtos;
using Domain.Dtos.Produtos;
using Domain.Model;
using Domain.Ports;

namespace Business.Services
{
    public class ProdutoService : Service<ProdutoDomain>, IProdutoService
    {
        private readonly IRepository<ProdutoDomain> _repository;
        private readonly IUnitOfWork _unitOfWork;
        public ProdutoService(IRepository<ProdutoDomain> repository, IUnitOfWork unitOfWork)
        : base(repository, unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<ProdutoDomain>> AdicionarAsync(CreateProduto dto)
        {

            var exists = await _repository.ObterPaginadoAsync($"CodigoBarra == \"{dto.CodigoBarra}\"", limit:1, offset:0);
            if(exists.Total>0) return Response<ProdutoDomain>.Fail("Produto com mesmo código de barra já existe.");

            var result = await _repository.AdicionarAsync(new ProdutoDomain
            {
                Nome = dto.Nome,
                CodigoBarra = dto.CodigoBarra,
                EstoqueMinimo = dto.EstoqueMinimo,
                UnidadeMedidaId = dto.UnidadeMedidaId
            });
            var commit = await _unitOfWork.CommitAsync();
            
            if(!commit.Success) return Response<ProdutoDomain>.Fail(commit.Message);

            return Response<ProdutoDomain>.Ok(result.Data); 
        }

        public Task<Response<ProdutoDomain>> AtualizarAsync(Guid id, ProdutoDomain entidade)
        {
            throw new NotImplementedException();
        }

        public async Task<ListResponse<ProdutoDTO>> Listar(string? nome, int page, int pageSize)
        {
            var filter = string.IsNullOrEmpty(nome) ? null : $"Nome == \"{nome}\"";
            var result = await _repository.ObterPaginadoAsync(filter, pageSize, (page - 1) * pageSize, ["UnidadeMedida", "FichaTecnica"]);
            var response = result.Data.Select(p => new ProdutoDTO
            {
                Id = p.Id,
                Nome = p.Nome,
                CodigoBarra = p.CodigoBarra,
                UnidadeMedida = p.UnidadeMedida,
                FichaTecnica = p.FichaTecnica,
                Insumo = p.Insumo
            }).ToList();

            return new ListResponse<ProdutoDTO>
            {
                Data = response,
                Total = result.Total
            };
        }

        public Task<ListResponse<ProdutoDomain>> ObterPaginadoAsync(Expression<Func<ProdutoDomain, bool>>? predicado = null, string? filter = null, int? limit = null, int? offset = null)
        {
            return _repository.ObterPaginadoAsync(filter, limit, offset, ["UnidadeMedida"]);
        }

        public async Task<Response<ProdutoDomain>> ObterPorCodigoDeBarrasAsync(string codigoBarras)
        {
            var produtoProximoVencer = await _repository.ObterPaginadoAsync(codigoBarras, 0, 0, ["UnidadeMedida"]);

            var produto = produtoProximoVencer.Data.FirstOrDefault(c=>c.CodigoBarra.ToUpper()
                                                        .Equals(codigoBarras.ToUpper()));

            if(produto==null) return Response<ProdutoDomain>.Fail("Produto não encontrado");

            return Response<ProdutoDomain>.Ok(produto);
        }

        public Task<Response<ProdutoDomain>> ObterPorIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<bool>> RemoverAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}