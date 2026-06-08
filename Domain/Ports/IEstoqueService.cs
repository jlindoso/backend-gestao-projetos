using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Dtos;
using Domain.Dtos.Estoque;
using Domain.Model;

namespace Domain.Ports
{
    public interface IEstoqueService
    {
        public Task<Response<EstoqueDomain>> EntradaAsync(EntradaEstoqueDTO entidade);
        public Task<Response<bool>> SaidaAsync(SaidaEstoqueDTO entidade);
        public Task<Response<SaldoAtualDTO>> SaldoAtualAsync(string codigoBarras);
        public Task<Response<List<EstoqueDomain>>> ItensCriticosAsync();
        public Task<Response<EstoqueDomain>> MovimentacaoAsync(SaidaEstoqueDTO entidade, Guid TipoSaidaId);

        public Task<Response<List<EstoqueDTO>>> Listar(string? codigoBarras);
    }
}