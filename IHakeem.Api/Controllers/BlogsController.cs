using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using iHakeem.Api.Controllers;
using iHakeem.Application.Blogs.Categories.CommandHandlers.CreateOrUpdate;
using iHakeem.Application.Blogs.Categories.QueryHandlers.Detail;

namespace iHakeem.Api.Blogs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ApiControllerBase
    {
        public BlogsController(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        [HttpPost("CreateCategories")]
        public async Task<IActionResult> CreateCategories([FromBody] CreateOrUpdateCategoriesRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpPut("EditCategories")]
        public async Task<IActionResult> EditCategories([FromBody] CreateOrUpdateCategoriesRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpGet("GetCategories")]
        public async Task<IActionResult> GetCategories([FromQuery] GetCategoriesRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpGet("GetAllCategories")]
        public async Task<IActionResult> GetAllCategories()
        {
            var response = await Mediator.Send(new GetAllCategoriesDetailRequestDTO());
            return HandleResponse(response);
        }
    }
}
