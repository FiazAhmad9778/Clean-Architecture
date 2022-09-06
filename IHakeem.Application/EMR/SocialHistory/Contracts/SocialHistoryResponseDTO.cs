using iHakeem.SharedKernal.BaseDomain;

namespace iHakeem.Application.EMR.SocialHistory.Contracts
{
    public class SocialHistoryResponseDTO : AuditEntity<long>
    {
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
        public string AlcoholNotes { get; set; }
        public long QuitYearAlcohal { get; set; }

        public bool IsDepressedAndHopeless { get; set; }
        public bool IsInterestedOrPleasure { get; set; }
        public long PatientId { get; set; }
    }
}
