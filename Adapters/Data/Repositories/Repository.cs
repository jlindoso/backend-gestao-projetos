using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Dtos;
using Domain.Model;

using Domain.Ports;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DataDBContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(DataDBContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public Task<Response<T>> ObterPorIdAsync(Guid id) =>
            ExecuteSafeAsync(async () =>
            {
                var entidade = await _dbSet.FindAsync(id);

                if (entidade == null)
                    return Response<T>.Fail("Registro não encontrado");

                return Response<T>.Ok(entidade);
            });

        public Task<Response<T>> AdicionarAsync(T entidade) =>
            ExecuteSafeAsync(async () =>
            {
                await _dbSet.AddAsync(entidade);
                return Response<T>.Ok(entidade);
            });


        public Task<ListResponse<T>> ObterPaginadoAsync(
            string? filter = null,
            int? limit = null,
            int? offset = null) =>

            ExecuteSafeListAsync(async () =>
                {

                    IQueryable<T> query = _dbSet.AsNoTracking();


                    query = query.Where(c => EF.Property<bool>(c, "Deleted") == false);


                    int total = await query.CountAsync();


                            if (offset.HasValue && offset > 0) query = query.Skip(offset.Value);
                            if (limit.HasValue && limit > 0) query = query.Take(limit.Value);


                            var dados = await query.ToListAsync();

                            return new ListResponse<T>
                            {
                                Data = dados,
                Total = total,
                Limit = limit ?? 0,
                Offset = offset ?? 0
            };
});

        public void Atualizar(T entidade)
        {
            _dbSet.Update(entidade);
        }

        public void Remover(T entidade)
        {
            _dbSet.Remove(entidade);
        }

        protected async Task<Response<TResult>> ExecuteSafeAsync<TResult>(Func<Task<Response<TResult>>> action) where TResult : class
        {
            try
            {
                return await action();
            }
            catch (Exception ex)
            {
                return Response<TResult>.Fail($"Erro no banco de dados: {ex.Message}");
            }
        }

        protected async Task<ListResponse<TResult>> ExecuteSafeListAsync<TResult>(Func<Task<ListResponse<TResult>>> action) where TResult : class
        {
            try
            {
                return await action();
            }
            catch (Exception)
            {

                return new ListResponse<TResult>
                {
                    Data = Enumerable.Empty<TResult>(),
                    Total = 0
                };
            }
        }
    }
}