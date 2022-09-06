using FluentValidation;
using iHakeem.Application.EMR.ExerciseHistory.Contracts;
using MediatR;
using System;

namespace iHakeem.Application.EMR.ExerciseHistory.CommandHandlers.Edit
{
    public class EditExerciseHistoryRequestDTO : IRequest<ExerciseHistoryResponseDTO>
    {
        public long Id { get; set; }
        public bool IsExercise { get; set; }
        public string ExerciseType { get; set; }
        public long? NumberOfDaysPerWeek { get; set; }
        public string HobbiesOrActivitiesNotes { get; set; }


        public class EditExerciseHistoryRequestDTOValidator : AbstractValidator<EditExerciseHistoryRequestDTO>
        {
            public EditExerciseHistoryRequestDTOValidator()
            {
                RuleFor(x => x.Id).NotEmpty();
                RuleFor(x => x.IsExercise).NotEmpty();
            }
        }
    }

}
