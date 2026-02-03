using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Dtos;
using Domain.Dtos.Auth;
using Domain.Model;

namespace Domain.Ports
{
    public interface IAuthService
    {
        public Task<Response<UsuarioLogadoDto>> RealizarLogin(LoginDto login);


        public Task<Response<UsuarioDomain>> AddUsuarioAsync(UsuarioDomain user, string password, string perfil);
    }
}