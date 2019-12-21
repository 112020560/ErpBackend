using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Catalogs;
using Entities.Request;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly ICatalogs _catalogs;
        public CatalogController(ICatalogs catalogs)
        {
            _catalogs = catalogs;
        }

        [EnableCors("AllowAllOrigins")]
        [HttpPost]
        public async Task<IActionResult> Catalog(CatalogRequest request)
        {
            var result = await _catalogs.GetAllAsync<CatalogRequest>(request);
            return Ok(result);
        }
    }
}