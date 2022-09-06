using FluentValidation;
using iHakeem.Application.EMR.SurgicalHistory.Contracts;
using MediatR;
using System;

namespace iHakeem.Application.EMR.SurgicalHistory.CommandHandlers.Create
{
    public class CreateSurgicalHistoryRequestDTO : IRequest<SurgicalHistoryResponseDTO>
    {
        public string SurgeryType { get; set; }
        public string SurgeonName { get; set; }
        public long? SurgeryYear { get; set; }
        public string SurgeryNotes { get; set; }

        public class CreateSurgicalHistoryRequestDTOValidator : AbstractValidator<CreateSurgicalHistoryRequestDTO>
        {
            public CreateSurgicalHistoryRequestDTOValidator()
            {
                RuleFor(x => x.SurgeryType).NotEmpty();
            }
        }
    }

}
