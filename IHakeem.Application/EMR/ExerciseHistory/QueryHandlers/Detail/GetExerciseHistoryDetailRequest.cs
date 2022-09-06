using iHakeem.Application.EMR.ExerciseHistory.Contracts;
using MediatR;

namespace iHakeem.Application.EMR.ExerciseHistory.QueryHandlers.Detail
{
    public class GetExerciseHistoryRequestDTO : IRequest<ExerciseHistoryResponseDTO>
    {
        public long Id { get; set; }
    }
}
