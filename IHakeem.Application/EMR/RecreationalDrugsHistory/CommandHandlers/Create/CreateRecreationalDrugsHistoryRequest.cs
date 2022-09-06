using FluentValidation;
using iHakeem.Application.EMR.RecreationalDrugsHistory.Contracts;
using MediatR;
using System;

namespace iHakeem.Application.EMR.RecreationalDrugsHistory.CommandHandlers.Create
{
    public class CreateRecreationalDrugsHistoryRequestDTO : IRequest<RecreationalDrugsHistoryResponseDTO>
    {
        public long DrugId { get; set; }
        public string Type { get; set; }
        public long? AmountPerWeek { get; set; }
        public long? LastUsed { get; set; }
        public string RecreationalDrugsHistoryNotes { get; set; }


        public class CreateRecreationalDrugsHistoryRequestDTOValidator : AbstractValidator<CreateRecreationalDrugsHistoryRequestDTO>
        {
            public CreateRecreationalDrugsHistoryRequestDTOValidator()
            {
                RuleFor(x => x.DrugId).NotEmpty();
            }
        }
    }

}
