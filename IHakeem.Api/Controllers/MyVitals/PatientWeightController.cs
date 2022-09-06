using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using iHakeem.Application.MyVitals.PatientWeight.CommandHandlers.Delete;
using iHakeem.Application.MyVitals.PatientWeight.QueryHandlers.Detail;
using Microsoft.AspNetCore.Mvc;
using iHakeem.Api.Controllers;
using iHakeem.Application.MyVitals.PatientWeight.CommandHandlers.CreateOrUpdate;

namespace iHakeem.Api.MyVitals.PatientWeight.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientWeightController : ApiControllerBase
    {
        public PatientWeightController(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreatePatientWeight([FromBody] CreateOrUpdatePatientWeightRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpPut("Edit")]
        public async Task<IActionResult> EditPatientWeight([FromBody] CreateOrUpdatePatientWeightRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeletePatientWeight([FromBody] PatientWeightDeleteRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpGet("Get")]
        public async Task<IActionResult> GetPatientWeight([FromQuery] GetPatientWeightRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllPatientWeight()
        {
            var response = await Mediator.Send(new GetAllPatientWeightDetailRequestDTO());
            return HandleResponse(response);
        }
    }
}
