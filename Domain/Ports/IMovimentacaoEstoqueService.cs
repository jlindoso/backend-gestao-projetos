using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Dtos;
using Domain.Dtos.Movimentacao;
using Domain.Model;

namespace Domain.Ports
{
    public interface IMovimentacaoEstoqueService
    {
        public Task<Response<MovimentacaoEstoqueDomain>> Movimentar(MovimentacaoDTO entidade, Guid TipoSaidaId);
    }
}