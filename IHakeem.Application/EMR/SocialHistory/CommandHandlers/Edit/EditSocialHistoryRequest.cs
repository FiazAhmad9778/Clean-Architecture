using FluentValidation;
using iHakeem.Application.EMR.SocialHistory.Contracts;
using MediatR;

namespace iHakeem.Application.EMR.SocialHistory.CommandHandlers.Edit
{
    public class EditSocialHistoryRequestDTO : IRequest<SocialHistoryResponseDTO>
    {
        public long Id { get; set; }
        public long SmokingId { get; set; }
        public long TobaccoTypeId { get; set; }
        public long NumberOfYears { get; set; }
        public long AmountPerDay { get; set; }
        public long QuitYear { get; set; }
        public string SmokingNotes { get; set; }

        public long CaffeineId { get; set; }
        public long NumberOfCaffeinatedDrinksPerDay { get; set; }
        public string CaffeineNotes { get; set; }

        public long AlcoholId { get; set; }
        public long NumberOfDrinksPerWeek { get; set; }
        public string PreferredDrink { get; set; }
        public long QuitYearAlcohal { get; set; }
        public string AlcoholNotes { get; set; }

        public bool IsDepressedAndHopeless { get; set; }
        public bool IsInterestedOrPleasure { get; set; }
        public class EditSocialHistoryRequestDTOValidator : AbstractValidator<EditSocialHistoryRequestDTO>
        {
            public EditSocialHistoryRequestDTOValidator()
            {
                RuleFor(x => x.Id).NotEmpty();
                RuleFor(x => x.SmokingId).NotEmpty();
                RuleFor(x => x.CaffeineId).NotEmpty();
                RuleFor(x => x.AlcoholId).NotEmpty();
                RuleFor(x => x.IsDepressedAndHopeless).NotEmpty();
                RuleFor(x => x.IsInterestedOrPleasure).NotEmpty();
            }
        }
    }

}
