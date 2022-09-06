using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using iHakeem.Api.Controllers;
using iHakeem.Application.MyVitals.VitalsPatientHistory.QueryHandlers.Detail;

namespace iHakeem.Api.EMR.EMR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VitalsController : ApiControllerBase
    {
        public VitalsController(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }
        [HttpGet("GetAllPatientVitalsHistory")]
        public async Task<IActionResult> GetAllPatientVitalsHistory()
        {
            var response = await Mediator.Send(new GetAllVitalsPatientHistoryDetailRequestDTO());
            return HandleResponse(response);
        }
    }
}
