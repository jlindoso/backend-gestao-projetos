using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Dtos;
using Domain.Dtos.Auth;
using Domain.Model;
using Domain.Ports;
using Microsoft.AspNetCore.Identity;


namespace Business.Services
{
    public class AuthService : IAuthService
    {
        private readonly IJwtTokenService _tokenService;
        private readonly UserManager<UsuarioDomain> _userManager;
        public AuthService(IJwtTokenService tokenService, UserManager<UsuarioDomain> userManager)
        {
            _tokenService = tokenService;
            _userManager = userManager;
        }

        public async Task<Response<UsuarioDomain>> AddUsuarioAsync(UsuarioDomain user, string password, string perfil)
        {
            try
            {
                user.Id = Guid.NewGuid();
                var result = await _userManager.CreateAsync(user, password);
                if (!result.Succeeded)
                    throw new Exception(result?.Errors?.FirstOrDefault()?.Description);
               

                return Response<UsuarioDomain>.Ok(user);
            }
            catch (System.Exception ex)
            {
                return Response<UsuarioDomain>.Fail($"Erro ao criar usuário: {ex.Message}");
            }

        }

        public async Task<Response<UsuarioLogadoDto>> RealizarLogin(LoginDto login)
        {
            var user = await _userManager.FindByEmailAsync(login.Email);

            if (user == null)
                return Response<UsuarioLogadoDto>.Fail("Credenciais inválidas.");

            var result = await _userManager.CheckPasswordAsync(
                user, login.Password);

            if (!result)
                return Response<UsuarioLogadoDto>.Fail("Senha inválida.");

            var roles = await _userManager.GetRolesAsync(user);
            var token = _tokenService.GenerateToken(user, roles);

            return Response<UsuarioLogadoDto>.Ok(new()
            {
                Email = user.NormalizedEmail,
                Nome = user.Nome,
                Token = token
            });
        }
    }
}