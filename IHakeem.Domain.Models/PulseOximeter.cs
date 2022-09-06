using System;
using System.Collections.Generic;
using iHakeem.SharedKernal.BaseDomain;

namespace iHakeem.Domain.Models
{
    public class PulseOximeter : AuditEntity<long>
    {
        public PulseOximeter()
        {
        }
        public float BloodOxygen { get; set; }
        public float PulseRate { get; set; }
        public DateTime PulseOximeterDateAndTime { get; set; }
        public long PatientId { get; set; }
        public Patient PatientDetails { get; set; }
    }
}
