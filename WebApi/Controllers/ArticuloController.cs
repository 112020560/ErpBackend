using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Articulos;
using Entities.Request;
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
        private readonly IBusquedaAvanzada _busqueda;
        public ArticuloController(IArtuclos articulos, IBusquedaAvanzada busqueda)
        {
            _artuclos = articulos;
            _busqueda = busqueda;
        }


        [EnableCors("AllowAllOrigins")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var response = await _artuclos.FindAsync<object>(new { PK_INV_MTR_PRODUCTO = id}).ConfigureAwait(false);
            return Ok(response);
        }

        [EnableCors("AllowAllOrigins")]
        [HttpPost]
        public async Task<IActionResult> post(ArticuloRequest model)
        {
            var response = await _busqueda.GetAllAsync(model).ConfigureAwait(false);
            return Ok(response);
        }
    }
}