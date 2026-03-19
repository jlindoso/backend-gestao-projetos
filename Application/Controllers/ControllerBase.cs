using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Ports;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ControllerBase<T> : ControllerBase where T : class
    {

        protected readonly IService<T> _service;

        public ControllerBase(IService<T> service)
        {
            _service = service;
        }

        [HttpGet("{id:guid}")]
        public virtual async Task<IActionResult> ObterPorId(Guid id)
        {
            var response = await _service.ObterPorIdAsync(id);

            if (!response.Success)
                return NotFound(response);

            return Ok(response);
        }

        [HttpGet]
        public virtual async Task<IActionResult> ObterPaginado([FromQuery] int limit = 50, [FromQuery] int offset = 0)
        {
            var response = await _service.ObterPaginadoAsync(null, null, limit, offset);
            return Ok(response);
        }

        [HttpPost]
        public virtual async Task<IActionResult> Adicionar([FromBody] T entidade)
        {
            var response = await _service.AdicionarAsync(entidade);
            if (!response.Success)
                return BadRequest(response);
            return StatusCode(201, response);
        }

        [HttpPut("{id:guid}")]
        public virtual async Task<IActionResult> Atualizar(Guid id, [FromBody] T entidade)
        {
            var response = await _service.AtualizarAsync(id, entidade);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpDelete("{id:guid}")]
        public virtual async Task<IActionResult> Remover(Guid id)
        {
            var response = await _service.RemoverAsync(id);
            if (!response.Success)
                return BadRequest(response);
            return Ok(response);
        }

    }
}