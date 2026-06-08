using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Dtos;
using Domain.Model;
using Domain.Ports;

namespace Business.Services
{
    public class FichaTecnicaService : IFichaTecnicaService
    {
        private readonly IRepository<FichaTecnica> _repository;
        private readonly IRepository<ProdutoDomain> _produtoRepository;
        private readonly IUnitOfWork _unitOfWork;
        public FichaTecnicaService(IRepository<FichaTecnica> repository, IRepository<ProdutoDomain> produtoRepository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _produtoRepository = produtoRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Response<FichaTecnica>> Atualizar(FichaTecnica entidade)
        {
            var currentResponse = await _repository.ObterPorIdAsync(entidade.Id);
            if (!currentResponse.Success)
                return Response<FichaTecnica>.Fail("Ficha técnica não encontrada");

            var produtoResponse = await _produtoRepository.ObterPorIdAsync(entidade.ProdutoId);
            if (!produtoResponse.Success)
                return Response<FichaTecnica>.Fail("Produto não encontrado");

            var duplicated = await _repository.ObterPaginadoAsync($"ProdutoId:{entidade.ProdutoId}", limit: 1, offset: 0);
            var duplicatedFicha = duplicated.Data.FirstOrDefault();
            if (duplicatedFicha != null && duplicatedFicha.Id != entidade.Id)
                return Response<FichaTecnica>.Fail("O Produto já possui ficha técnica cadastrada");

            var current = currentResponse.Data;
            if (current == null)
                return Response<FichaTecnica>.Fail("Ficha técnica não encontrada");

            current.Nome = entidade.Nome;
            current.ModoPreparo = entidade.ModoPreparo;
            current.ProdutoId = entidade.ProdutoId;
            current.UnidadeMedidaId = entidade.UnidadeMedidaId;
            current.TempoMedio = entidade.TempoMedio;

            _repository.Atualizar(current);
            var commit = await _unitOfWork.CommitAsync();

            if (!commit.Success) return Response<FichaTecnica>.Fail(commit.Message);

            return Response<FichaTecnica>.Ok(current);
        }

        public async Task<Response<FichaTecnica>> Criar(FichaTecnica entidade)
        {
            var produtoResponse = await _produtoRepository.ObterPorIdAsync(entidade.ProdutoId);
            if (!produtoResponse.Success)
                return Response<FichaTecnica>.Fail("Produto não encontrado");

            var exists = await _repository.ObterPaginadoAsync($"ProdutoId:{entidade.ProdutoId}", limit: 1, offset: 0);
            if (exists.Total > 0) return Response<FichaTecnica>.Fail("O Produto já possui ficha técnica cadastrada");

            var result = await _repository.AdicionarAsync(new FichaTecnica
            {
                Nome = entidade.Nome,
                ModoPreparo = entidade.ModoPreparo,
                ProdutoId = entidade.ProdutoId,
                UnidadeMedidaId = entidade.UnidadeMedidaId,
                TempoMedio = entidade.TempoMedio

            });
            var commit = await _unitOfWork.CommitAsync();
            
            if(!commit.Success) return Response<FichaTecnica>.Fail(commit.Message);

            return Response<FichaTecnica>.Ok(result.Data); 
        }

        public async Task<Response<FichaTecnica>> Deletar(Guid id)
        {
            var currentResponse = await _repository.ObterPorIdAsync(id);
            if (!currentResponse.Success)
                return Response<FichaTecnica>.Fail("Ficha técnica não encontrada");

            var current = currentResponse.Data;
            if (current == null)
                return Response<FichaTecnica>.Fail("Ficha técnica não encontrada");

            _repository.Remover(current);
            var commit = await _unitOfWork.CommitAsync();

            if (!commit.Success) return Response<FichaTecnica>.Fail(commit.Message);

            return Response<FichaTecnica>.Ok(current);
        }

        public async Task<Response<FichaTecnica>> ObterPorId(Guid id)
        {
            var response = await _repository.ObterPaginadoAsync($"ProdutoId:{id}", limit: 1, offset: 0, "Produto", "UnidadeMedida");
            var entidade = response.Data.FirstOrDefault();

            if (entidade == null)
                return Response<FichaTecnica>.Fail("Ficha técnica não encontrada para o produto informado");

            return Response<FichaTecnica>.Ok(entidade);
        }
    }
}