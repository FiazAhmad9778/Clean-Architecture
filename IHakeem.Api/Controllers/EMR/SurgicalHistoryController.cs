using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using iHakeem.Application.EMR.SurgicalHistory.CommandHandlers.Create;
using iHakeem.Application.EMR.SurgicalHistory.CommandHandlers.Delete;
using iHakeem.Application.EMR.SurgicalHistory.CommandHandlers.Edit;
using iHakeem.Application.EMR.SurgicalHistory.QueryHandlers.Detail;
using Microsoft.AspNetCore.Mvc;
using iHakeem.Api.Controllers;

namespace iHakeem.Api.EMR.SurgicalHistory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurgicalHistoryController : ApiControllerBase
    {
        public SurgicalHistoryController(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        [HttpPost("CreateSurgicalHistory")]
        public async Task<IActionResult> CreateSurgicalHistory([FromBody] CreateSurgicalHistoryRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpPut("EditSurgicalHistory")]
        public async Task<IActionResult> EditSurgicalHistory([FromBody] EditSurgicalHistoryRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpDelete("DeleteSurgicalHistory")]
        public async Task<IActionResult> DeleteSurgicalHistory([FromBody] DeleteSurgicalHistoryRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpGet("GetSurgicalHistory")]
        public async Task<IActionResult> GetSurgicalHistory([FromQuery] GetSurgicalHistoryRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpGet("GetAllSurgicalHistory")]
        public async Task<IActionResult> GetAllSurgicalHistory()
        {
            var response = await Mediator.Send(new GetAllSurgicalHistoryDetailRequestDTO());
            return HandleResponse(response);
        }
    }
}
