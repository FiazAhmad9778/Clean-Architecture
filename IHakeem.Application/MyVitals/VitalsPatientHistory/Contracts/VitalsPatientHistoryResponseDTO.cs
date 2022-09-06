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
using iHakeem.Application.MyVitals.PatientBloodPressure.Contracts;
using iHakeem.Application.MyVitals.PatientTemperature.Contracts;
using iHakeem.Application.MyVitals.PatientWeight.Contracts;
using iHakeem.Application.MyVitals.PulseOximeter.Contracts;
using iHakeem.SharedKernal.BaseDomain;
using System.Collections.Generic;

namespace iHakeem.Application.MyVitals.VitalsPatientHistory.Contracts
{
    public class VitalsPatientHistoryResponseDTO
    {
        public VitalsPatientHistoryResponseDTO()
        {
        }

        public List<PatientBloodPressureResponseDTO> PatientBloodPressure { get; set; }
        public List<PatientTemperatureResponseDTO> PatientTemperature { get; set; }
        public List<PatientWeightResponseDTO> PatientWeight { get; set; }
        public List<PulseOximeterResponseDTO> PulseOximeter { get; set; }
    }
}
