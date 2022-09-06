using iHakeem.Application.Files.Upload;
using iHakeem.Application.Lookup.Create;
using iHakeem.Application.Lookup.QueryHandlers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaticDataController : ApiControllerBase
    {
        public StaticDataController(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        [HttpGet("lookup")]
        public async Task<IActionResult> getLookup([FromQuery] GetLookupByTypeRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }

        [HttpPost("lookup/save")]
        public async Task<IActionResult> CreateOrUpdateLookup([FromBody] CreateOrUpdateLookupRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }

        [HttpPost("uploadimage")]
        public async Task<IActionResult> UploadImage([FromForm] UploadFileRequestDTO request, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(request, cancellationToken);
            return HandleResponse(response);
        }

    }
}
