using FluentValidation;
using iHakeem.Application.EMR.PatientAllergiesHistory.Contracts;
using MediatR;
using System;

namespace iHakeem.Application.EMR.PatientAllergiesHistory.CommandHandlers.Edit
{
    public class EditPatientAllergiesHistoryRequestDTO : IRequest<PatientAllergiesHistoryResponseDTO>
    {
        public long Id { get; set; }
        public string AllergyTo { get; set; }
        public string Reaction { get; set; }
        public string AllergyNotes { get; set; }

        public class EditPatientAllergiesHistoryRequestDTOValidator : AbstractValidator<EditPatientAllergiesHistoryRequestDTO>
        {
            public EditPatientAllergiesHistoryRequestDTOValidator()
            {
                RuleFor(x => x.Id).NotEmpty();
                RuleFor(x => x.AllergyTo).NotEmpty();
                RuleFor(x => x.Reaction).NotEmpty();
            }
        }
    }

}
