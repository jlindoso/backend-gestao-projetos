using Domain.Model;
using Domain.Ports;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class FichaTecnicaItemsController : ControllerBase
    {
        private readonly IFichaTecnicaItemsService _service;

        public FichaTecnicaItemsController(IFichaTecnicaItemsService service)
        {
            _service = service;
        }

        [HttpPost]
        public virtual async Task<IActionResult> Criar([FromBody] FichaTecnicaItems entidade)
        {
            var response = await _service.Criar(entidade);
            if (!response.Success)
                return BadRequest(response);

            return StatusCode(201, response);
        }

        [HttpPut]
        public virtual async Task<IActionResult> Atualizar([FromBody] FichaTecnicaItems entidade)
        {
            var response = await _service.Atualizar(entidade);
            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpDelete("{id:guid}")]
        public virtual async Task<IActionResult> Deletar(Guid id)
        {
            var response = await _service.Deletar(id);
            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        public virtual async Task<IActionResult> ObterPorId(Guid id)
        {
            var response = await _service.ObterPorId(id);
            if (!response.Success)
                return NotFound(response);

            return Ok(response);
        }
    }
}
