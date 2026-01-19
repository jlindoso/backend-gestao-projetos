using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Application.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProjetoController : ControllerBase
    {
        private readonly ILogger<ProjetoController> _logger;

        public ProjetoController(ILogger<ProjetoController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "Listar")]
        public ActionResult<IEnumerable<ProjetoDomain>> Listar()
        {
            return Ok(new List<ProjetoDomain>());
        }


        [HttpPost(Name = "Criar")]
        public ActionResult<ProjetoDomain> Criar(ProjetoDomain model)
        {
            return Ok(new ProjetoDomain());
        }



    }
}