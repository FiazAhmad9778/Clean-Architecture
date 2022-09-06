using iHakeem.SharedKernal.BaseDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace iHakeem.Domain.Models
{
    public class GetAllPatientVitalsHistory 
    {
        public GetAllPatientVitalsHistory()
        {
        }

        public List<PatientBloodPressure> PatientBloodPressure { get; set; }
        public List<PatientTemperature> PatientTemperature { get; set; }
        public List<PatientWeight> PatientWeight { get; set; }
        public List<PulseOximeter> PulseOximeter { get; set; }

    }
}
