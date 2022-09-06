using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using iHakeem.Application.EMR.DetailPregnancies.CommandHandlers.Delete;
using iHakeem.Application.EMR.DetailPregnancies.QueryHandlers.Detail;
using Microsoft.AspNetCore.Mvc;
using iHakeem.Api.Controllers;
using iHakeem.Application.EMR.DetailPregnancies.CommandHandlers.CreateOrUpdate;

namespace iHakeem.Api.EMR.DetailPregnancies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailPregnanciesController : ApiControllerBase
    {
        public DetailPregnanciesController(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateDetailPregnancies([FromBody] CreateOrUpdateDetailPregnanciesRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpPut("Edit")]
        public async Task<IActionResult> EditDetailPregnancies([FromBody] CreateOrUpdateDetailPregnanciesRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteDetailPregnancies([FromBody] DetailPregnanciesDeleteRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpGet("Get")]
        public async Task<IActionResult> GetDetailPregnancies([FromQuery] GetDetailPregnanciesRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllDetailPregnancies()
        {
            var response = await Mediator.Send(new GetAllDetailPregnanciesDetailRequestDTO());
            return HandleResponse(response);
        }
    }
}
