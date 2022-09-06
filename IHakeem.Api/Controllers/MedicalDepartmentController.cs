using iHakeem.Application.MedicalDepartments.QueryHandlers.BrowseList;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalDepartmentController : ApiControllerBase
    {
        public MedicalDepartmentController(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] BrowseMedicalDepartmentFilterDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
    }
}
