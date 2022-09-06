using iHakeem.Application.EMR.ExerciseHistory.Contracts;
using MediatR;

namespace iHakeem.Application.EMR.ExerciseHistory.CommandHandlers.Delete
{
    public class DeleteExerciseHistoryRequestDTO : IRequest<bool>
    {
        public long Id { get; set; }
    }
}
