using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using iHakeem.Application.EMR.HospitalizationInformation.CommandHandlers.Create;
using iHakeem.Application.EMR.HospitalizationInformation.CommandHandlers.Delete;
using iHakeem.Application.EMR.HospitalizationInformation.CommandHandlers.Edit;
using iHakeem.Application.EMR.HospitalizationInformation.QueryHandlers.Detail;
using Microsoft.AspNetCore.Mvc;
using iHakeem.Api.Controllers;

namespace iHakeem.Api.EMR.HospitalizationInformation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalizationInformationController : ApiControllerBase
    {
        public HospitalizationInformationController(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        [HttpPost("CreateHospitalizationInformation")]
        public async Task<IActionResult> CreateHospitalizationInformation([FromBody] CreateHospitalizationInformationRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpPut("EditHospitalizationInformation")]
        public async Task<IActionResult> EditHospitalizationInformation([FromBody] EditHospitalizationInformationRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpDelete("DeleteHospitalizationInformation")]
        public async Task<IActionResult> DeleteHospitalizationInformation([FromBody] DeleteHospitalizationInformationRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpGet("GetHospitalizationInformation")]
        public async Task<IActionResult> GetHospitalizationInformation([FromQuery] GetHospitalizationInformationRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpGet("GetAllHospitalizationInformation")]
        public async Task<IActionResult> GetAllHospitalizationInformation()
        {
            var response = await Mediator.Send(new GetAllHospitalizationInformationDetailRequestDTO());
            return HandleResponse(response);
        }
    }
}
