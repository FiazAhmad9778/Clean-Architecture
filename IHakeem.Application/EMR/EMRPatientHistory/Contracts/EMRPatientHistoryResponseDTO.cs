using iHakeem.Application.EMR.CurrentMedication.Contracts;
using iHakeem.Application.EMR.DetailPregnancies.Contracts;
using iHakeem.Application.EMR.ExerciseHistory.Contracts;
using iHakeem.Application.EMR.HospitalizationInformation.Contracts;
using iHakeem.Application.EMR.MyPhysicians.Contracts;
using iHakeem.Application.EMR.PatientAllergiesHistory.Contracts;
using iHakeem.Application.EMR.PatientFamilyHistory.Contracts;
using iHakeem.Application.EMR.PatientHobbiesHistory.Contracts;
using iHakeem.Application.EMR.PatientMedicalHistory.Contracts;
using iHakeem.Application.EMR.PharmacyInformation.Contracts;
using iHakeem.Application.EMR.PregnanciesHistory.Contracts;
using iHakeem.Application.EMR.RecreationalDrugsHistory.Contracts;
using iHakeem.Application.EMR.SocialHistory.Contracts;
using iHakeem.Application.EMR.SurgicalHistory.Contracts;
using iHakeem.SharedKernal.BaseDomain;
using System.Collections.Generic;

namespace iHakeem.Application.EMR.EMRPatientHistory.Contracts
{
    public class EMRPatientHistoryResponseDTO
    {
        public EMRPatientHistoryResponseDTO()
        {
        }

        public List<CurrentMedicationResponseDTO> CurrentMedication { get; set; }
        public List<ExerciseHistoryResponseDTO> ExerciseHistory { get; set; }
        public List<MyPhysiciansResponseDTO> MyPhysicians { get; set; }
        public List<PatientMedicalHistoryResponseDTO> PatientMedicalHistory { get; set; }
        public List<RecreationalDrugsHistoryResponseDTO> RecreationalDrugsHistory { get; set; }
        public List<SocialHistoryResponseDTO> SocialHistory { get; set; }
        public List<SurgicalHistoryResponseDTO> SurgicalHistory { get; set; }
        public List<PatientAllergiesHistoryResponseDTO> PatientAllergies { get; set; }
        public List<PharmacyInformationResponseDTO> PharmacyInformation { get; set; }
        public List<HospitalizationInformationResponseDTO> HospitalizationInformation { get; set; }
        public List<PatientFamilyHistoryResponseDTO> PatientFamilyHistory { get; set; }
        public List<PatientHobbiesHistoryResponseDTO> PatientHobbiesHistory { get; set; }
        public List<PregnanciesHistoryResponseDTO> PregnanciesHistory { get; set; }
        public List<DetailPregnanciesResponseDTO> DetailPregnancies { get; set; }
    }
}
