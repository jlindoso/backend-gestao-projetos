using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Domain.Dtos;
using Domain.Model;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using Domain.Ports;


namespace Business.Services
{
    public class JwtTokenService: IJwtTokenService
    {
        private readonly JwtSettings _settings;

        public JwtTokenService(JwtSettings settings)
        {
            _settings = settings;
        }

        public string GenerateToken(UsuarioDomain user, IList<string>? roles = null)
        {
            var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            if (roles != null && roles.Any())
            {
                claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));
            }

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_settings.SecretKey
                ?? throw new InvalidOperationException("JwtSettings:SecretKey não configurada."))
            );

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expires = DateTime.UtcNow.AddHours(_settings.ExpireHours);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: expires,
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}