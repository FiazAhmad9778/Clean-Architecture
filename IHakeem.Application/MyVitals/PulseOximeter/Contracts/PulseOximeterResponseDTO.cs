using iHakeem.SharedKernal.BaseDomain;
using System;

namespace iHakeem.Application.MyVitals.PulseOximeter.Contracts
{
    public class PulseOximeterResponseDTO : AuditEntity<long>
    {
        public float BloodOxygen { get; set; }
        public float PulseRate { get; set; }
        public DateTime PulseOximeterDateAndTime { get; set; }
        public long PatientId { get; set; }
    }
}
