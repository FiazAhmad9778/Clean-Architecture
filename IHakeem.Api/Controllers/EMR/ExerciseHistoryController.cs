using iHakeem.Api.Controllers;
using iHakeem.Application.EMR.ExerciseHistory.CommandHandlers.Create;
using iHakeem.Application.EMR.ExerciseHistory.CommandHandlers.Delete;
using iHakeem.Application.EMR.ExerciseHistory.CommandHandlers.Edit;
using iHakeem.Application.EMR.ExerciseHistory.QueryHandlers.Detail;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Api.EMR.ExerciseHistory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseHistoryController : ApiControllerBase
    {
        public ExerciseHistoryController(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        [HttpPost("CreateExerciseHistory")]
        public async Task<IActionResult> CreateExerciseHistory([FromBody] CreateExerciseHistoryRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpPut("EditExerciseHistory")]
        public async Task<IActionResult> EditExerciseHistory([FromBody] EditExerciseHistoryRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpDelete("DeleteExerciseHistory")]
        public async Task<IActionResult> DeleteExerciseHistory([FromBody] DeleteExerciseHistoryRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpGet("GetExerciseHistory")]
        public async Task<IActionResult> GetExerciseHistory([FromQuery] GetExerciseHistoryRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpGet("GetAllExerciseHistory")]
        public async Task<IActionResult> GetAllExerciseHistory()
        {
            var response = await Mediator.Send(new GetAllExerciseHistoryDetailRequestDTO());
            return HandleResponse(response);
        }
    }
}
