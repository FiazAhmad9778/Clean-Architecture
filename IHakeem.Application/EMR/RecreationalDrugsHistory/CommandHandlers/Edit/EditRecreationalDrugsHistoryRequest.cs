using FluentValidation;
using iHakeem.Application.EMR.RecreationalDrugsHistory.Contracts;
using MediatR;
using System;

namespace iHakeem.Application.EMR.RecreationalDrugsHistory.CommandHandlers.Edit
{
    public class EditRecreationalDrugsHistoryRequestDTO : IRequest<RecreationalDrugsHistoryResponseDTO>
    {
        public long Id { get; set; }
        public long DrugId { get; set; }
        public string Type { get; set; }
        public long? AmountPerWeek { get; set; }
        public long? LastUsed { get; set; }
        public string RecreationalDrugsHistoryNotes { get; set; }


        public class EditRecreationalDrugsHistoryRequestDTOValidator : AbstractValidator<EditRecreationalDrugsHistoryRequestDTO>
        {
            public EditRecreationalDrugsHistoryRequestDTOValidator()
            {
                RuleFor(x => x.Id).NotEmpty();
                RuleFor(x => x.DrugId).NotEmpty();
            }
        }
    }

}
