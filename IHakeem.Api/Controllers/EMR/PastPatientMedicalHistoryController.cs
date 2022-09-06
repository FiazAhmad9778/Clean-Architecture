using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using iHakeem.Application.EMR.PatientMedicalHistory.CommandHandlers.Create;
using iHakeem.Application.EMR.PatientMedicalHistory.CommandHandlers.Delete;
using iHakeem.Application.EMR.PatientMedicalHistory.CommandHandlers.Edit;
using iHakeem.Application.EMR.PatientMedicalHistory.QueryHandlers.Detail;
using Microsoft.AspNetCore.Mvc;
using iHakeem.Api.Controllers;

namespace iHakeem.Api.EMR.PatientMedicalHistory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PastPatientMedicalHistoryController : ApiControllerBase
    {
        public PastPatientMedicalHistoryController(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        [HttpPost("CreatePastPatientMedicalHistory")]
        public async Task<IActionResult> CreatePastPatientMedicalHistory([FromBody] CreatePatientMedicalHistoryRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpPut("EditPastPatientMedicalHistory")]
        public async Task<IActionResult> EditPastPatientMedicalHistory([FromBody] EditPatientMedicalHistoryRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpDelete("DeletePastPatientMedicalHistory")]
        public async Task<IActionResult> DeletePastPatientMedicalHistory([FromBody] DeletePatientMedicalHistoryRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpGet("GetPastPatientMedicalHistory")]
        public async Task<IActionResult> GetPastPatientMedicalHistory([FromQuery] GetPatientMedicalHistoryRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpGet("GetAllPastPatientMedicalHistory")]
        public async Task<IActionResult> GetAllPastPatientMedicalHistory()
        {
            var response = await Mediator.Send(new GetAllPatientMedicalHistoryDetailRequestDTO());
            return HandleResponse(response);
        }
    }
}
