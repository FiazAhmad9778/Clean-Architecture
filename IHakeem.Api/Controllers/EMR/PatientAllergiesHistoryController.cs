using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using iHakeem.Application.EMR.PatientAllergiesHistory.CommandHandlers.Create;
using iHakeem.Application.EMR.PatientAllergiesHistory.CommandHandlers.Delete;
using iHakeem.Application.EMR.PatientAllergiesHistory.CommandHandlers.Edit;
using iHakeem.Application.EMR.PatientAllergiesHistory.QueryHandlers.Detail;
using Microsoft.AspNetCore.Mvc;
using iHakeem.Api.Controllers;

namespace iHakeem.Api.EMR.PatientAllergiesHistory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientAllergiesHistoryController : ApiControllerBase
    {
        public PatientAllergiesHistoryController(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        [HttpPost("CreatePatientAllergiesHistory")]
        public async Task<IActionResult> CreatePatientAllergiesHistory([FromBody] CreatePatientAllergiesHistoryRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpPut("EditPatientAllergiesHistory")]
        public async Task<IActionResult> EditPatientAllergiesHistory([FromBody] EditPatientAllergiesHistoryRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpDelete("DeletePatientAllergiesHistory")]
        public async Task<IActionResult> DeletePatientAllergiesHistory([FromBody] DeletePatientAllergiesHistoryRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpGet("GetPatientAllergiesHistory")]
        public async Task<IActionResult> GetPatientAllergiesHistory([FromQuery] GetPatientAllergiesHistoryRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpGet("GetAllPatientAllergiesHistory")]
        public async Task<IActionResult> GetAllPatientAllergiesHistory()
        {
            var response = await Mediator.Send(new GetAllPatientAllergiesHistoryDetailRequestDTO());
            return HandleResponse(response);
        }
    }
}
