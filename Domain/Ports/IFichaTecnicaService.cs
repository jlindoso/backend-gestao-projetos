using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Dtos;
using Domain.Model;

namespace Domain.Ports
{
    public interface IFichaTecnicaService
    {
        public Task<Response<FichaTecnica>> Criar(FichaTecnica entidade);
        public Task<Response<FichaTecnica>> Atualizar(FichaTecnica entidade);
        public Task<Response<FichaTecnica>> Deletar(Guid id);
        public Task<Response<FichaTecnica>> ObterPorId(Guid id);
        
    }
}