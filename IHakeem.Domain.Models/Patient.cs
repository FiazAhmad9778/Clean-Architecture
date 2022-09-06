using iHakeem.SharedKernal.BaseDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace iHakeem.Domain.Models
{
    public class Patient : AuditEntity<long>
    {
        public Patient()
        {
        }
        public long UserId { get; set; }

        public string MaritialStatusId { get; set; }
        public string PreferedLanguageId { get; set; }
        public string EthnicityId { get; set; }
        public string BloodGroupId { get; set; }
        public string HomeContact { get; set; }
        public string WorkContact { get; set; }
        public string CountryId { get; set; }
        public string StateId { get; set; }
        public string CityId { get; set; }
        public string ZipCode { get; set; }
        public string PrimaryAddress { get; set; }
        public string SecondaryAddress { get; set; }
        public LookupData MaritialStatus { get; set; }
        public LookupData PreferedLanguage { get; set; }
        public LookupData Ethnicity { get; set; }
        public LookupData BloodGroup { get; set; }
        public LookupData Country { get; set; }
        public LookupData City { get; set; }
        public LookupData State { get; set; }
        public ApplicationUser User { get; set; }

        public virtual ICollection<PatientEmergencyContact> EmergencyContact { get; set; }
        public virtual ICollection<PatientGaurdian> Gaurdian { get; set; }
        public virtual ICollection<PatientSocialInfo> SocialInformation { get; set; }
        public virtual ICollection<CurrentMedication> CurrentMedication { get; set; }
        public virtual ICollection<ExerciseHistory> ExerciseHistory { get; set; }
        public virtual ICollection<MyPhysicians> MyPhysicians { get; set; }
        public virtual ICollection<PatientMedicalHistory> PatientMedicalHistory { get; set; }
        public virtual ICollection<RecreationalDrugsHistory> RecreationalDrugsHistory { get; set; }
        public virtual ICollection<SocialHistory> SocialHistory { get; set; }
        public virtual ICollection<SurgicalHistory> SurgicalHistory { get; set; }
        public virtual ICollection<PatientAllergiesHistory> PatientAllergiesHistory { get; set; }
        public virtual ICollection<PharmacyInformation> PharmacyInformation { get; set; }
        public virtual ICollection<HospitalizationInformation> HospitalizationInformation { get; set; }
        public virtual ICollection<PatientFamilyHistory> PatientFamilyHistory { get; set; }
        public virtual ICollection<PatientHobbiesHistory> PatientHobbiesHistory { get; set; }
        public virtual ICollection<PregnanciesHistory> PregnanciesHistory { get; set; }
        public virtual ICollection<DetailPregnancies> DetailPregnancies { get; set; }
        public virtual ICollection<PatientBloodPressure> PatientBloodPressure { get; set; }
        public virtual ICollection<PulseOximeter> PulseOximeter { get; set; }
        public virtual ICollection<PatientWeight> PatientWeight { get; set; }
        public virtual ICollection<PatientTemperature> PatientTemperature { get; set; }

    }
}
