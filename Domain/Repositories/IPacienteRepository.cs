using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Model.Repositories
{
    public interface IPacienteRepository
{
    Task<List<PacienteDomain>> GetAllAsync(string? filter);
    Task<PacienteDomain?> GetByIdAsync(Guid id);
    Task<PacienteDomain> AddAsync(PacienteDomain paciente);
    Task<PacienteDomain> UpdateAsync(PacienteDomain paciente);
    Task DeleteAsync(Guid id);
}
}