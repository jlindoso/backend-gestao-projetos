using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Dtos;
using Domain.Dtos.Estoque;
using Domain.Dtos.Movimentacao;
using Domain.Dtos.Produtos;
using Domain.Model;
using Domain.Ports;

namespace Business.Services
{
    public class EstoqueService : Service<EstoqueDomain>, IEstoqueService
    {
        private readonly IRepository<EstoqueDomain> _repository;
        private readonly IProdutoService _produtoService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMovimentacaoEstoqueService _movimentacaoEstoqueService;

        public EstoqueService(IRepository<EstoqueDomain> repository,
                                IProdutoService produtoService,
                                IUnitOfWork unitOfWork, IMovimentacaoEstoqueService movimentacaoEstoqueService)
        : base(repository, unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _produtoService = produtoService;
            _movimentacaoEstoqueService = movimentacaoEstoqueService;
        }

        public async Task<Response<EstoqueDomain>> EntradaAsync(EntradaEstoqueDTO entidade)
        {

            using var transaction = await _unitOfWork.BeginTransactionAsync();

            try
            {
                var produto = await _produtoService.ObterPorCodigoDeBarrasAsync(entidade.CodigoBarras);
                if (!produto.Success) return Response<EstoqueDomain>.Fail("Produto não encontrado");

                var estoque = new EstoqueDomain
                {
                    ProdutoId = produto.Data.Id,
                    Quantidade = entidade.Quantidade,
                    DataEntrada = DateTime.UtcNow,
                    ValorUnitario = entidade.ValorUnitario,
                    DataValidade = entidade.DataValidade,
                    Lote = entidade.Lote
                };

                var insert = await _repository.AdicionarAsync(estoque);
                if (!insert.Success) return Response<EstoqueDomain>.Fail(insert.Message);

                var movi = await _movimentacaoEstoqueService.Movimentar(new MovimentacaoDTO
                {
                    ProdutoId = produto.Data.Id,
                    Quantidade = entidade.Quantidade,
                    TipoSaidaId = TiposDeMovimentacao.ENTRADA
                }, TiposDeMovimentacao.ENTRADA);

                if (!movi.Success)
                {
                    await transaction.RollbackAsync();
                    return Response<EstoqueDomain>.Fail(movi.Message);
                }

                var res = await _unitOfWork.CommitAsync();
                if (!res.Success)
                {
                    await transaction.RollbackAsync();
                    return Response<EstoqueDomain>.Fail(res.Message);
                }
                await transaction.CommitAsync();

                return Response<EstoqueDomain>.Ok(estoque);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return Response<EstoqueDomain>.Fail($"Erro inesperado: {ex.Message}");
            }
        }

        public Task<Response<List<EstoqueDomain>>> ItensCriticosAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Response<List<EstoqueDTO>>> Listar(string? codigoBarras)
        {
            var result = await _repository.ObterPaginadoAsync(codigoBarras != null ? $"Produto.CodigoBarra:{codigoBarras}" : null, limit: null, offset: null, includes: "Produto");
            var response = result.Data.ToList()
                    .GroupBy(i => i.ProdutoId)
                    .Select(g => new EstoqueDTO
                    {
                        ProdutoId = g.Key,
                        ProdutoNome = g.First().Produto.Nome,
                        CodigoBarra = g.First().Produto.CodigoBarra,
                        QuantidadeAtual = g.Sum(x => x.Quantidade),
                        QuantidadeMinima = g.First().Produto.EstoqueMinimo,
                        Insumo = g.First().Produto.Insumo
                    })
                    .ToList();
            
            
            return Response<List<EstoqueDTO>>.Ok(response);
        }

        public Task<Response<EstoqueDomain>> MovimentacaoAsync(SaidaEstoqueDTO entidade, Guid TipoSaidaId)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<bool>> SaidaAsync(SaidaEstoqueDTO entidade)
        {
            using var transaction = await _unitOfWork.BeginTransactionAsync();

            try
            {
                var produto = await _produtoService.ObterPorCodigoDeBarrasAsync(entidade.CodigoBarras);
                if (!produto.Success) return Response<bool>.Fail("Produto não encontrado");

                var filtro = $"ProdutoId:{produto.Data.Id}";

                var itens = await _repository.ObterPaginadoAsync(filtro, limit: null, offset: null);

                int totalDisponivel = itens.Data.Sum(x => x.Quantidade);
                if (totalDisponivel < entidade.Quantidade || totalDisponivel == 0)
                    return Response<bool>.Fail($"Saldo insuficiente. Disponível total: {totalDisponivel}");


                var lotesDisponiveis = itens.Data
                                            .OrderBy(c => c.DataValidade)
                                            .ThenBy(p => p.Quantidade)
                                            .ThenBy(p => p.DataEntrada)
                                            .ToList();

                int quantidadeRestante = entidade.Quantidade;

                // 3. Loop de consumo de lotes
                foreach (var lote in lotesDisponiveis)
                {
                    if (quantidadeRestante <= 0) break;

                    if (lote.Quantidade >= quantidadeRestante)
                    {
                        lote.Quantidade -= quantidadeRestante;
                        quantidadeRestante = 0;
                    }
                    else
                    {
                        quantidadeRestante -= lote.Quantidade;
                        lote.Quantidade = 0;
                    }
                    _repository.Atualizar(lote);
                }


                var movi = await _movimentacaoEstoqueService.Movimentar(new MovimentacaoDTO
                {
                    ProdutoId = produto.Data.Id,
                    Quantidade = entidade.Quantidade,
                    DataSaida = DateTime.UtcNow,
                    TipoSaidaId = TiposDeMovimentacao.SAIDA
                }, TiposDeMovimentacao.SAIDA);

                if (!movi.Success)
                {
                    await transaction.RollbackAsync();
                    return Response<bool>.Fail($"Falha ao registrar histórico: {movi.Message}");
                }

                var res = await _unitOfWork.CommitAsync();
                if (!res.Success)
                {
                    await transaction.RollbackAsync();
                    return Response<bool>.Fail(res.Message);
                }
                await transaction.CommitAsync();
                return Response<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return Response<bool>.Fail($"Erro crítico na saída de estoque: {ex.Message}");
            }
        }
        public async Task<Response<SaldoAtualDTO>> SaldoAtualAsync(string codigoBarras)
        {
            var produto = await _produtoService.ObterPorCodigoDeBarrasAsync(codigoBarras);

            if (!produto.Success) return Response<SaldoAtualDTO>.Fail("Produto não encontrado");

            var filtro = $"ProdutoId:{produto.Data.Id}";
            var itens = await _repository.ObterPaginadoAsync(filtro, limit: null, offset: null);
            int totalDisponivel = itens.Data.Sum(x => x.Quantidade);
            var saldo = new SaldoAtualDTO
            {
                Estoques = itens.Data.ToList(),
                Total = itens.Data.Sum(x => x.Quantidade),
                ValorTotal = itens.Data.Sum(x => x.Quantidade * x.ValorUnitario)

            };

            return Response<SaldoAtualDTO>.Ok(saldo);
        }
    }
}