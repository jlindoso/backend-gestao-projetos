using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Dtos;

namespace Domain.Ports
{
    public interface IRepository<T> where T : class
    {
        Task<Response<T>> ObterPorIdAsync(Guid id);

        Task<ListResponse<T>> ObterPaginadoAsync(
            string? filter = null, 
            int? limit = null, 
            int? offset = null);
        Task<Response<T>> AdicionarAsync(T entidade);
        
        void Atualizar(T entidade);
        void Remover(T entidade);
    }
}