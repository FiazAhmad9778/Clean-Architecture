


using iHakeem.Application.EMR.ExerciseHistory.Contracts;
using MediatR;
using System.Collections.Generic;

namespace iHakeem.Application.EMR.ExerciseHistory.QueryHandlers.Detail
{
    public class GetAllExerciseHistoryDetailRequestDTO : IRequest<List<ExerciseHistoryResponseDTO>>
    {
    }
}
