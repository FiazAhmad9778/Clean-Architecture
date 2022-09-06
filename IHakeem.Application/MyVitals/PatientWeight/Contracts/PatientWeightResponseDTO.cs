using iHakeem.SharedKernal.BaseDomain;
using System;

namespace iHakeem.Application.MyVitals.PatientWeight.Contracts
{
    public class PatientWeightResponseDTO : AuditEntity<long>
    {
        public float Weight { get; set; }
        public long UnitId { get; set; }
        public DateTime PatientWeightDateAndTime { get; set; }
        public long PatientId { get; set; }
    }
}
