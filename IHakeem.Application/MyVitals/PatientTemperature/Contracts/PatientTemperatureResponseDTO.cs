using iHakeem.SharedKernal.BaseDomain;
using System;

namespace iHakeem.Application.MyVitals.PatientTemperature.Contracts
{
    public class PatientTemperatureResponseDTO : AuditEntity<long>
    {
        public float Temperature { get; set; }
        public long UnitId { get; set; }
        public DateTime PatientTemperatureDateAndTime { get; set; }
        public long PatientId { get; set; }
    }
}
