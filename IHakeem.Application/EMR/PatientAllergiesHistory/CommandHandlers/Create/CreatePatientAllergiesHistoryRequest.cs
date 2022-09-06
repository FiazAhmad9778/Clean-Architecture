using FluentValidation;
using iHakeem.Application.EMR.PatientAllergiesHistory.Contracts;
using MediatR;
using System;

namespace iHakeem.Application.EMR.PatientAllergiesHistory.CommandHandlers.Create
{
    public class CreatePatientAllergiesHistoryRequestDTO : IRequest<PatientAllergiesHistoryResponseDTO>
    {
        public string AllergyTo { get; set; }
        public string Reaction { get; set; }
        public string AllergyNotes { get; set; }

        public class CreatePatientAllergiesHistoryRequestDTOValidator : AbstractValidator<CreatePatientAllergiesHistoryRequestDTO>
        {
            public CreatePatientAllergiesHistoryRequestDTOValidator()
            {
                RuleFor(x => x.AllergyTo).NotEmpty();
                RuleFor(x => x.Reaction).NotEmpty();
            }
        }
    }

}
