using System;
using System.Collections.Generic;
using iHakeem.SharedKernal.BaseDomain;

namespace iHakeem.Domain.Models
{
    public class PatientBloodPressure : AuditEntity<long>
    {
        public PatientBloodPressure()
        {
        }
        public long Systolic { get; set; }
        public long Diastolic { get; set; }
        public DateTime BloodPressureDateAndTime { get; set; }
        public long PatientId { get; set; }
        public Patient PatientDetails { get; set; }
    }
}
