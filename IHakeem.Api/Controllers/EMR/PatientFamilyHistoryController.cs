using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using iHakeem.Application.EMR.PatientFamilyHistory.CommandHandlers.Delete;
using iHakeem.Application.EMR.PatientFamilyHistory.QueryHandlers.Detail;
using Microsoft.AspNetCore.Mvc;
using iHakeem.Api.Controllers;
using iHakeem.Application.EMR.PatientFamilyHistory.CommandHandlers.CreateOrUpdate;

namespace iHakeem.Api.EMR.PatientFamilyHistory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientFamilyHistoryController : ApiControllerBase
    {
        public PatientFamilyHistoryController(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreatePatientFamilyHistory([FromBody] CreateOrUpdatePatientFamilyHistoryRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpPut("Edit")]
        public async Task<IActionResult> EditPatientFamilyHistory([FromBody] CreateOrUpdatePatientFamilyHistoryRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeletePatientFamilyHistory([FromBody] PatientFamilyHistoryDeleteRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpGet("Get")]
        public async Task<IActionResult> GetPatientFamilyHistory([FromQuery] GetPatientFamilyHistoryRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllPatientFamilyHistory()
        {
            var response = await Mediator.Send(new GetAllPatientFamilyHistoryDetailRequestDTO());
            return HandleResponse(response);
        }
    }
}
