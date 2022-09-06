using iHakeem.SharedKernal.BaseDomain;
using System;

namespace iHakeem.Application.MyVitals.PatientBloodPressure.Contracts
{
    public class PatientBloodPressureResponseDTO : AuditEntity<long>
    {
        public long Systolic { get; set; }
        public long Diastolic { get; set; }
        public DateTime BloodPressureDateAndTime { get; set; }
        public long PatientId { get; set; }
    }
}
