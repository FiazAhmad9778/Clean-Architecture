using iHakeem.SharedKernal.BaseDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace iHakeem.Domain.Models
{
    public class GetAllPatientHistory 
    {
        public GetAllPatientHistory()
        {
        }

        public  List<CurrentMedication> CurrentMedication { get; set; }
        public  List<ExerciseHistory> ExerciseHistory { get; set; }
        public  List<MyPhysicians> MyPhysicians { get; set; }
        public  List<PatientMedicalHistory> PatientMedicalHistory { get; set; }
        public  List<RecreationalDrugsHistory> RecreationalDrugsHistory { get; set; }
        public  List<SocialHistory> SocialHistory { get; set; }
        public  List<SurgicalHistory> SurgicalHistory { get; set; }
        public  List<PatientAllergiesHistory> PatientAllergies { get; set; }
        public  List<PharmacyInformation> PharmacyInformation { get; set; }
        public List<HospitalizationInformation> HospitalizationInformation { get; set; }
        public List<PatientFamilyHistory> PatientFamilyHistory { get; set; }
        public List<PatientHobbiesHistory> PatientHobbiesHistory { get; set; }
        public List<PregnanciesHistory> PregnanciesHistory { get; set; }
        public List<DetailPregnancies> DetailPregnancies { get; set; }

    }
}
