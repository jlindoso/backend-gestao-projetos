using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Dtos;
using Domain.Dtos.Paciente;
using Domain.Model;

namespace Domain.Ports
{
    public interface IPacienteService
    {
        Task<Response<List<PacienteDomain>>> GetAllAsync(string? filter = null);
        Task<Response<PacienteDomain?>> GetByIdAsync(Guid id);
        Task<Response<PacienteDomain>> AddAsync(PacienteCreateDto paciente);
        Task<Response<PacienteDomain>> UpdateAsync(PacienteDomain paciente);
        Task DeleteAsync(Guid id);
    }
}