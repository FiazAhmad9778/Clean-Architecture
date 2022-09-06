using FluentValidation;
using iHakeem.Application.EMR.ExerciseHistory.Contracts;
using MediatR;
using System;

namespace iHakeem.Application.EMR.ExerciseHistory.CommandHandlers.Create
{
    public class CreateExerciseHistoryRequestDTO : IRequest<ExerciseHistoryResponseDTO>
    {
        public bool IsExercise { get; set; }
        public string ExerciseType { get; set; }
        public long? NumberOfDaysPerWeek { get; set; }
        public string HobbiesOrActivitiesNotes { get; set; }


        public class CreateExerciseHistoryRequestDTOValidator : AbstractValidator<CreateExerciseHistoryRequestDTO>
        {
            public CreateExerciseHistoryRequestDTOValidator()
            {
                RuleFor(x => x.IsExercise).NotEmpty();
            }
        }
    }

}
