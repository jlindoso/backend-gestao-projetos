using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Model;
using Domain.Ports;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoSaidaController : ControllerBase<TipoSaidaDomain>
    {
        public TipoSaidaController(IService<TipoSaidaDomain> service) : base(service)
        {
        }
    }
}