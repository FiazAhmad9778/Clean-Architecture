using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using iHakeem.Application.EMR.PatientHobbiesHistory.CommandHandlers.Delete;
using iHakeem.Application.EMR.PatientHobbiesHistory.QueryHandlers.Detail;
using Microsoft.AspNetCore.Mvc;
using iHakeem.Api.Controllers;
using iHakeem.Application.EMR.PatientHobbiesHistory.CommandHandlers.CreateOrUpdate;

namespace iHakeem.Api.EMR.PatientHobbiesHistory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientHobbiesHistoryController : ApiControllerBase
    {
        public PatientHobbiesHistoryController(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreatePatientHobbiesHistory([FromBody] CreateOrUpdatePatientHobbiesHistoryRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpPut("Edit")]
        public async Task<IActionResult> EditPatientHobbiesHistory([FromBody] CreateOrUpdatePatientHobbiesHistoryRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeletePatientHobbiesHistory([FromBody] PatientHobbiesHistoryDeleteRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpGet("Get")]
        public async Task<IActionResult> GetPatientHobbiesHistory([FromQuery] GetPatientHobbiesHistoryRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllPatientHobbiesHistory()
        {
            var response = await Mediator.Send(new GetAllPatientHobbiesHistoryDetailRequestDTO());
            return HandleResponse(response);
        }
    }
}
