using iHakeem.SharedKernal.BaseDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace iHakeem.Domain.Models
{
    public class PatientMedication : AuditEntity<long>
    {
        public long PatientId { get; set; }
        public long DoctorId { get; set; }
        public long AppointmentId { get; set; }
        public string Medication { get; set; }
        public string Frequency { get; set; }
        public string Dose { get; set; }
        public string Unit { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? StopDate { get; set; }
        public string MedicationComments { get; set; }
        public string EncounterComments { get; set; }

        public Appointment Appointment { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }

    }
}
