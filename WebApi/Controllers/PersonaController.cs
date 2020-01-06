using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Catalogs;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonas _personas;
        public PersonaController(IPersonas personas)
        {
            _personas = personas;
        }

        [EnableCors("AllowAllOrigins")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var result = await _personas.FindAsync<object>(new { P_PK_MTR_PERSONA = id }).ConfigureAwait(false);
            return Ok(result);
        }
    }
}