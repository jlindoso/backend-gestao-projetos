using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Dtos.Estoque;
using Domain.Model;
using Domain.Ports;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class EstoqueController : ControllerBase
    {
        private readonly IEstoqueService _service;
        public EstoqueController(IEstoqueService service) 
        {
            _service = service;
        }

        [HttpPost]
        public virtual async Task<IActionResult> Entrada([FromBody] EntradaEstoqueDTO entidade)
        {
            var response = await _service.EntradaAsync(entidade);
            if (!response.Success)
                return BadRequest(response);
            return StatusCode(201, response);
        }


        [HttpPost]
        public virtual async Task<IActionResult> Saida([FromBody] SaidaEstoqueDTO entidade)
        {
            var response = await _service.SaidaAsync(entidade);
            if (!response.Success)
                return BadRequest(response);
            return StatusCode(201, response);
        }


        [HttpGet("{codigoBarras}")]
        public virtual async Task<IActionResult> SaldoAtual(string codigoBarras)
        {
            var response = await _service.SaldoAtualAsync(codigoBarras);
            if (!response.Success)
                return BadRequest(response);
            return Ok(response);
        }



        [HttpGet("{codigoBarras}")]
        public virtual async Task<IActionResult> Listar(string? codigoBarras)
        {
            var response = await _service.Listar(codigoBarras);
            if (!response.Success)
                return BadRequest(response);
            return StatusCode(201, response);
        }
    }
}