using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using iHakeem.Application.EMR.PharmacyInformation.CommandHandlers.Create;
using iHakeem.Application.EMR.PharmacyInformation.CommandHandlers.Delete;
using iHakeem.Application.EMR.PharmacyInformation.CommandHandlers.Edit;
using iHakeem.Application.EMR.PharmacyInformation.QueryHandlers.Detail;
using Microsoft.AspNetCore.Mvc;
using iHakeem.Api.Controllers;

namespace iHakeem.Api.EMR.PharmacyInformation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmacyInformationController : ApiControllerBase
    {
        public PharmacyInformationController(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        [HttpPost("CreatePharmacyInformation")]
        public async Task<IActionResult> CreatePharmacyInformation([FromBody] CreatePharmacyInformationRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpPut("EditPharmacyInformation")]
        public async Task<IActionResult> EditPharmacyInformation([FromBody] EditPharmacyInformationRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpDelete("DeletePharmacyInformation")]
        public async Task<IActionResult> DeletePharmacyInformation([FromBody] DeletePharmacyInformationRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpGet("GetPharmacyInformation")]
        public async Task<IActionResult> GetPharmacyInformation([FromQuery] GetPharmacyInformationRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpGet("GetAllPharmacyInformation")]
        public async Task<IActionResult> GetAllPharmacyInformation()
        {
            var response = await Mediator.Send(new GetAllPharmacyInformationDetailRequestDTO());
            return HandleResponse(response);
        }
    }
}
