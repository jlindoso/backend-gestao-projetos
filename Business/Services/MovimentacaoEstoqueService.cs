using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Dtos;
using Domain.Dtos.Movimentacao;
using Domain.Model;
using Domain.Ports;

namespace Business.Services
{
    public class MovimentacaoEstoqueService : IMovimentacaoEstoqueService
    {
        private readonly IRepository<MovimentacaoEstoqueDomain> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public MovimentacaoEstoqueService(IRepository<MovimentacaoEstoqueDomain> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Response<MovimentacaoEstoqueDomain>> Movimentar(MovimentacaoDTO entidade, Guid TipoSaidaId)
        {
            if (!TiposDeMovimentacao.Existe(TipoSaidaId))
            {
                return Response<MovimentacaoEstoqueDomain>.Fail("Tipo de movimentação inválida");
            }
            await _repository.AdicionarAsync(new MovimentacaoEstoqueDomain
            {
                ProdutoId = entidade.ProdutoId,
                Quantidade = entidade.Quantidade,
                DataMovimentacao = entidade.DataSaida,
                TipoMovimentacaoId = TipoSaidaId
            });
            await _unitOfWork.CommitAsync();
            
            return Response<MovimentacaoEstoqueDomain>.Ok(new MovimentacaoEstoqueDomain
            {
                ProdutoId = entidade.ProdutoId,
                Quantidade = entidade.Quantidade,
                DataMovimentacao = entidade.DataSaida,
                TipoMovimentacaoId = TipoSaidaId
            });
        }
    }
}