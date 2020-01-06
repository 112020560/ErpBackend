using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Documents;
using Entities.Request;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [EnableCors("AllowAllOrigins")]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/{v:apiVersion}/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly IDocument _document;
        public DocumentsController(IDocument document)
        {
            _document = document;
        }
        // [Authorize]
        [EnableCors("AllowAllOrigins")]
        [HttpPost]
        public async Task<IActionResult> Save([FromBody] DocumentsRequest request)
        {
            var response = await _document.FindAsync(request).ConfigureAwait(false);
            return Ok(response);
        }
    }
}