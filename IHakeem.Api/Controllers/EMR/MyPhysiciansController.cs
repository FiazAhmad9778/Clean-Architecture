using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using iHakeem.Application.EMR.MyPhysicians.CommandHandlers.Create;
using iHakeem.Application.EMR.MyPhysicians.CommandHandlers.Delete;
using iHakeem.Application.EMR.MyPhysicians.CommandHandlers.Edit;
using iHakeem.Application.EMR.MyPhysicians.QueryHandlers.Detail;
using Microsoft.AspNetCore.Mvc;
using iHakeem.Api.Controllers;

namespace iHakeem.Api.EMR.MyPhysicians.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyPhysiciansController : ApiControllerBase
    {
        public MyPhysiciansController(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        [HttpPost("CreateMyPhysicians")]
        public async Task<IActionResult> CreateMyPhysicians([FromBody] CreateMyPhysiciansRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpPut("EditMyPhysicians")]
        public async Task<IActionResult> EditMyPhysicians([FromBody] EditMyPhysiciansRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpDelete("DeleteMyPhysicians")]
        public async Task<IActionResult> DeleteMyPhysicians([FromBody] DeleteMyPhysiciansRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpGet("GetMyPhysicians")]
        public async Task<IActionResult> GetMyPhysicians([FromQuery] GetMyPhysiciansRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpGet("GetAllMyPhysicians")]
        public async Task<IActionResult> GetAllMyPhysicians()
        {
            var response = await Mediator.Send(new GetAllMyPhysiciansDetailRequestDTO());
            return HandleResponse(response);
        }
    }
}
