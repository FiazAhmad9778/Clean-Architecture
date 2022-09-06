using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using iHakeem.Application.EMR.CurrentMedication.CommandHandlers.Create;
using iHakeem.Application.EMR.CurrentMedication.CommandHandlers.Delete;
using iHakeem.Application.EMR.CurrentMedication.CommandHandlers.Edit;
using iHakeem.Application.EMR.CurrentMedication.QueryHandlers.Detail;
using Microsoft.AspNetCore.Mvc;
using iHakeem.Api.Controllers;

namespace iHakeem.Api.EMR.CurrentMedication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrentMedicationController : ApiControllerBase
    {
        public CurrentMedicationController(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        [HttpPost("CreateCurrentMedication")]
        public async Task<IActionResult> CreateCurrentMedication([FromBody] CreateCurrentMedicationRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpPut("EditCurrentMedication")]
        public async Task<IActionResult> EditCurrentMedication([FromBody] EditCurrentMedicationRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpDelete("DeleteCurrentMedication")]
        public async Task<IActionResult> DeleteCurrentMedication([FromBody] DeleteCurrentMedicationRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpGet("GetCurrentMedication")]
        public async Task<IActionResult> GetCurrentMedication([FromQuery] GetCurrentMedicationDetailRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpGet("GetAllCurrentMedication")]
        public async Task<IActionResult> GetAllCurrentMedication()
        {
            var response = await Mediator.Send(new GetAllCurrentMedicationDetailRequestDTO());
            return HandleResponse(response);
        }
    }
}
