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
    public class CategoriasController : ControllerBase<CategoriaDomain>
    {
        public CategoriasController(IService<CategoriaDomain> service) : base(service)
        {
        }
    }
}