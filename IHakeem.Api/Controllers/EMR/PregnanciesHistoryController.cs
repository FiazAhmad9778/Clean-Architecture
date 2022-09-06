using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using iHakeem.Application.EMR.PregnanciesHistory.CommandHandlers.Delete;
using iHakeem.Application.EMR.PregnanciesHistory.QueryHandlers.Detail;
using Microsoft.AspNetCore.Mvc;
using iHakeem.Api.Controllers;
using iHakeem.Application.EMR.PregnanciesHistory.CommandHandlers.CreateOrUpdate;

namespace iHakeem.Api.EMR.PregnanciesHistory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PregnanciesHistoryController : ApiControllerBase
    {
        public PregnanciesHistoryController(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreatePregnanciesHistory([FromBody] CreateOrUpdatePregnanciesHistoryRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpPut("Edit")]
        public async Task<IActionResult> EditPregnanciesHistory([FromBody] CreateOrUpdatePregnanciesHistoryRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeletePregnanciesHistory([FromBody] PregnanciesHistoryDeleteRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpGet("Get")]
        public async Task<IActionResult> GetPregnanciesHistory([FromQuery] GetPregnanciesHistoryRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllPregnanciesHistory()
        {
            var response = await Mediator.Send(new GetAllPregnanciesHistoryDetailRequestDTO());
            return HandleResponse(response);
        }
    }
}
