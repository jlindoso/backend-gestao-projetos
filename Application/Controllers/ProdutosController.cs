using Domain.Dtos.Produtos;
using Domain.Ports;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _service;
        public ProdutosController(IProdutoService service)
        {
            _service = service;
        }
        [HttpPost]
        public virtual async Task<IActionResult> Adicionar([FromBody] CreateProduto entidade)
        {
            var response = await _service.AdicionarAsync(entidade);
            if (!response.Success)
                return BadRequest(response);
            return StatusCode(201, response);
        }


        [HttpGet]
        public virtual async Task<IActionResult> Listar([FromQuery] string? filter = null, [FromQuery] int? limit = null, [FromQuery] int? offset = 0)
        {
            var response = await _service.Listar(filter, limit ?? 10, offset ?? 0);
            return Ok(response);
        }
        


        [HttpGet]
        public virtual async Task<IActionResult> ObterPorCodigoBarras([FromQuery] string codigoBarras )
        {
            var response = await _service.ObterPorCodigoDeBarrasAsync(codigoBarras);
            return Ok(response);
        }
    }
}