using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using iHakeem.Application.MyVitals.PatientBloodPressure.CommandHandlers.Delete;
using iHakeem.Application.MyVitals.PatientBloodPressure.QueryHandlers.Detail;
using Microsoft.AspNetCore.Mvc;
using iHakeem.Api.Controllers;
using iHakeem.Application.MyVitals.PatientBloodPressure.CommandHandlers.CreateOrUpdate;

namespace iHakeem.Api.MyVitals.PatientBloodPressure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientBloodPressureController : ApiControllerBase
    {
        public PatientBloodPressureController(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreatePatientBloodPressure([FromBody] CreateOrUpdatePatientBloodPressureRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpPut("Edit")]
        public async Task<IActionResult> EditPatientBloodPressure([FromBody] CreateOrUpdatePatientBloodPressureRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeletePatientBloodPressure([FromBody] PatientBloodPressureDeleteRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpGet("Get")]
        public async Task<IActionResult> GetPatientBloodPressure([FromQuery] GetPatientBloodPressureRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllPatientBloodPressure()
        {
            var response = await Mediator.Send(new GetAllPatientBloodPressureDetailRequestDTO());
            return HandleResponse(response);
        }
    }
}
