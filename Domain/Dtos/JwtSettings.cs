using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class JwtSettings
    {
        public string SecretKey { get; set; } = string.Empty;
        public double ExpireHours { get; set; } = 1; // default 1h
    }
}