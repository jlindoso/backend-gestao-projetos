using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Dtos;
using Domain.Ports;

namespace Data.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DataDBContext _context;

        public UnitOfWork(DataDBContext context)
        {
            _context = context;
        }
        public async Task<Response<bool>> CommitAsync()
        {
            try
            {
                var linhasAfetadas = await _context.SaveChangesAsync();
                return Response<bool>.Ok(linhasAfetadas > 0);
            }
            catch (Exception ex)
            {
                return Response<bool>.Fail($"Falha ao salvar as alterações no banco de dados: {ex.Message}");
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}