using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using iHakeem.Application.EMR.SocialHistory.CommandHandlers.Create;
using iHakeem.Application.EMR.SocialHistory.CommandHandlers.Delete;
using iHakeem.Application.EMR.SocialHistory.CommandHandlers.Edit;
using iHakeem.Application.EMR.SocialHistory.QueryHandlers.Detail;
using Microsoft.AspNetCore.Mvc;
using iHakeem.Api.Controllers;

namespace iHakeem.Api.EMR.SocialHistory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialHistoryController : ApiControllerBase
    {
        public SocialHistoryController(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        [HttpPost("CreateSocialHistory")]
        public async Task<IActionResult> CreateSocialHistory([FromBody] CreateSocialHistoryRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpPut("EditSocialHistory")]
        public async Task<IActionResult> EditSocialHistory([FromBody] EditSocialHistoryRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpDelete("DeleteSocialHistory")]
        public async Task<IActionResult> DeleteSocialHistory([FromBody] DeleteSocialHistoryRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpGet("GetSocialHistory")]
        public async Task<IActionResult> GetSocialHistory([FromQuery] GetSocialHistoryRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpGet("GetAllSocialHistory")]
        public async Task<IActionResult> GetAllSocialHistory()
        {
            var response = await Mediator.Send(new GetAllSocialHistoryDetailRequestDTO());
            return HandleResponse(response);
        }
    }
}
