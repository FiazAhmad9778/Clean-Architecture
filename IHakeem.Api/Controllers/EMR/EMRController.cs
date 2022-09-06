using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using iHakeem.Api.Controllers;
using iHakeem.Application.EMR.EMRPatientHistory.QueryHandlers.Detail;

namespace iHakeem.Api.EMR.EMR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EMRController : ApiControllerBase
    {
        public EMRController(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }
        [HttpGet("GetAllPatientHistory")]
        public async Task<IActionResult> GetAllPatientHistory()
        {
            var response = await Mediator.Send(new GetAllPatientHistoryDetailRequestDTO());
            return HandleResponse(response);
        }
    }
}
