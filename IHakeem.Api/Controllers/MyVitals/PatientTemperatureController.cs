using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using iHakeem.Application.MyVitals.PatientTemperature.CommandHandlers.Delete;
using iHakeem.Application.MyVitals.PatientTemperature.QueryHandlers.Detail;
using Microsoft.AspNetCore.Mvc;
using iHakeem.Api.Controllers;
using iHakeem.Application.MyVitals.PatientTemperature.CommandHandlers.CreateOrUpdate;

namespace iHakeem.Api.MyVitals.PatientTemperature.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientTemperatureController : ApiControllerBase
    {
        public PatientTemperatureController(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreatePatientTemperature([FromBody] CreateOrUpdatePatientTemperatureRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpPut("Edit")]
        public async Task<IActionResult> EditPatientTemperature([FromBody] CreateOrUpdatePatientTemperatureRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeletePatientTemperature([FromBody] PatientTemperatureDeleteRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpGet("Get")]
        public async Task<IActionResult> GetPatientTemperature([FromQuery] GetPatientTemperatureRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllPatientTemperature()
        {
            var response = await Mediator.Send(new GetAllPatientTemperatureDetailRequestDTO());
            return HandleResponse(response);
        }
    }
}
