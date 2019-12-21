using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Articulos;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticuloController : ControllerBase
    {
        private readonly IArtuclos _artuclos;
        public ArticuloController(IArtuclos articulos)
        {
            _artuclos = articulos;
        }


        [EnableCors("AllowAllOrigins")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var response = await _artuclos.FindAsync<object>(new { PK_INV_MTR_PRODUCTO = id});
            return Ok(response);
        }
    }
}