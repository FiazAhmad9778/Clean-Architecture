using System;
using System.Collections.Generic;
using iHakeem.SharedKernal.BaseDomain;

namespace iHakeem.Domain.Models
{
    public class PatientWeight : AuditEntity<long>
    {
        public PatientWeight()
        {
        }
        public float Weight { get; set; }
        public long UnitId { get; set; }
        public DateTime PatientWeightDateAndTime { get; set; }
        public long PatientId { get; set; }
        public Patient PatientDetails { get; set; }
    }
}
