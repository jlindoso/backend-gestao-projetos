using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Model;
using Domain.Model.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly DataDBContext _context;

        public PacienteRepository(DataDBContext context)
        {
            _context = context;
        }

        public async Task<List<PacienteDomain>> GetAllAsync(string? filter)
        {
            var query = _context.Pacientes
                .Include(p => p.Usuario)
                .AsQueryable();

            if (!string.IsNullOrEmpty(filter))
            {
                filter = filter.ToLower();
                query = query.Where(p => p.Usuario.NomeSocial.ToLower().Contains(filter)
                                       || p.Usuario.CPF.Contains(filter) || p.Nome.Contains(filter));
            }

            return await query.ToListAsync();
        }

        public async Task<PacienteDomain?> GetByIdAsync(Guid id)
        {
            return await _context.Pacientes
                .Include(p => p.Usuario)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<PacienteDomain> AddAsync(PacienteDomain paciente)
        {
            await _context.Pacientes.AddAsync(paciente);
            await _context.SaveChangesAsync();
            return paciente;
        }

        public async Task<PacienteDomain> UpdateAsync(PacienteDomain paciente)
        {
            _context.Pacientes.Update(paciente);
            await _context.SaveChangesAsync();
            return paciente;
        }

        public async Task DeleteAsync(Guid id)
        {
            var paciente = await _context.Pacientes.FindAsync(id);
            if (paciente != null)
            {
                _context.Pacientes.Remove(paciente);
                await _context.SaveChangesAsync();
            }
        }
    }
}