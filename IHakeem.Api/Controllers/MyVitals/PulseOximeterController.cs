using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using iHakeem.Application.MyVitals.PulseOximeter.CommandHandlers.Delete;
using iHakeem.Application.MyVitals.PulseOximeter.QueryHandlers.Detail;
using Microsoft.AspNetCore.Mvc;
using iHakeem.Api.Controllers;
using iHakeem.Application.MyVitals.PulseOximeter.CommandHandlers.CreateOrUpdate;

namespace iHakeem.Api.MyVitals.PulseOximeter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PulseOximeterController : ApiControllerBase
    {
        public PulseOximeterController(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreatePulseOximeter([FromBody] CreateOrUpdatePulseOximeterRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpPut("Edit")]
        public async Task<IActionResult> EditPulseOximeter([FromBody] CreateOrUpdatePulseOximeterRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeletePulseOximeter([FromBody] PulseOximeterDeleteRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpGet("Get")]
        public async Task<IActionResult> GetPulseOximeter([FromQuery] GetPulseOximeterRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllPulseOximeter()
        {
            var response = await Mediator.Send(new GetAllPulseOximeterDetailRequestDTO());
            return HandleResponse(response);
        }
    }
}
