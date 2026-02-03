using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Model;

namespace Domain.Ports
{
    public interface IJwtTokenService
    {
        public string GenerateToken(UsuarioDomain user, IList<string>? roles = null);
    }
}