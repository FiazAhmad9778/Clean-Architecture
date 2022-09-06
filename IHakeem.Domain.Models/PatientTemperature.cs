using System;
using System.Collections.Generic;
using iHakeem.SharedKernal.BaseDomain;

namespace iHakeem.Domain.Models
{
    public class PatientTemperature : AuditEntity<long>
    {
        public PatientTemperature()
        {
        }
        public float Temperature { get; set; }
        public long UnitId { get; set; }
        public DateTime PatientTemperatureDateAndTime { get; set; }
        public long PatientId { get; set; }
        public Patient PatientDetails { get; set; }
    }
}
