using FluentValidation;
using iHakeem.Application.EMR.SurgicalHistory.Contracts;
using MediatR;
using System;

namespace iHakeem.Application.EMR.SurgicalHistory.CommandHandlers.Edit
{
    public class EditSurgicalHistoryRequestDTO : IRequest<SurgicalHistoryResponseDTO>
    {
        public long Id { get; set; }
        public string SurgeryType { get; set; }
        public string SurgeonName { get; set; }
        public long? SurgeryYear { get; set; }
        public string SurgeryNotes { get; set; }

        public class EditSurgicalHistoryRequestDTOValidator : AbstractValidator<EditSurgicalHistoryRequestDTO>
        {
            public EditSurgicalHistoryRequestDTOValidator()
            {
                RuleFor(x => x.Id).NotEmpty();
                RuleFor(x => x.SurgeryType).NotEmpty();
            }
        }
    }

}
