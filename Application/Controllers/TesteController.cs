using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TesteController : ControllerBase
    {
        [HttpGet("TesteAdmin")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> TesteAdmin()
        {
            return Ok("OK");
        }


        [HttpGet("Teste")]
        [Authorize]
        public async Task<IActionResult> Teste()
        {
            return Ok("OK");
        }
    }
}