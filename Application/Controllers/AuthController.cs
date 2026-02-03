using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Dtos;
using Domain.Model;
using Domain.Ports;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {

     

        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {

            _authService = authService;
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var result = await _authService.RealizarLogin(model);
            
            if(!result.Success)
                return BadRequest(result.Message);
                
            return Ok(result.Data);

            
        }
    }
}