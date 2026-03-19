using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Dtos;

namespace Domain.Ports
{
    public interface IService<T> where T : class
    {

        Task<Response<T>> ObterPorIdAsync(Guid id);

        Task<ListResponse<T>> ObterPaginadoAsync(
            Expression<Func<T, bool>>? predicado = null,
            string? filter = null,
            int? limit = null,
            int? offset = null);

        Task<Response<T>> AdicionarAsync(T entidade);

        Task<Response<T>> AtualizarAsync(Guid id, T entidade);

        Task<Response<bool>> RemoverAsync(Guid id);
    }
}