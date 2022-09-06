using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using iHakeem.Application.EMR.RecreationalDrugsHistory.CommandHandlers.Create;
using iHakeem.Application.EMR.RecreationalDrugsHistory.CommandHandlers.Delete;
using iHakeem.Application.EMR.RecreationalDrugsHistory.CommandHandlers.Edit;
using iHakeem.Application.EMR.RecreationalDrugsHistory.QueryHandlers.Detail;
using Microsoft.AspNetCore.Mvc;
using iHakeem.Api.Controllers;

namespace iHakeem.Api.EMR.RecreationalDrugsHistory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecreationalDrugsHistoryController : ApiControllerBase
    {
        public RecreationalDrugsHistoryController(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        [HttpPost("CreateRecreationalDrugsHistory")]
        public async Task<IActionResult> CreateRecreationalDrugsHistory([FromBody] CreateRecreationalDrugsHistoryRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpPut("EditRecreationalDrugsHistory")]
        public async Task<IActionResult> EditRecreationalDrugsHistory([FromBody] EditRecreationalDrugsHistoryRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpDelete("DeleteRecreationalDrugsHistory")]
        public async Task<IActionResult> DeleteRecreationalDrugsHistory([FromBody] DeleteRecreationalDrugsHistoryRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpGet("GetRecreationalDrugsHistory")]
        public async Task<IActionResult> GetRecreationalDrugsHistory([FromQuery] GetRecreationalDrugsHistoryRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpGet("GetAllRecreationalDrugsHistory")]
        public async Task<IActionResult> GetAllRecreationalDrugsHistory()
        {
            var response = await Mediator.Send(new GetAllRecreationalDrugsHistoryDetailRequestDTO());
            return HandleResponse(response);
        }
    }
}
