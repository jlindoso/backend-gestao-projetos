using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Dtos.Paciente;
using Domain.Ports;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteService _pacienteService;
        public PacienteController(IPacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }
        [HttpPost]
        public async Task<IActionResult> AddPacienteAsync([FromBody] PacienteCreateDto paciente)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var result = await _pacienteService.AddAsync(paciente);
            
            if(!result.Success)
                return BadRequest(result.Message);
                
            return Ok(result.Data);

            
        }
    }
}