using iHakeem.SharedKernal.BaseDomain;
using System;

namespace iHakeem.Application.EMR.SurgicalHistory.Contracts
{
    public class SurgicalHistoryResponseDTO : AuditEntity<long>
    {
        public string SurgeryType { get; set; }
        public string SurgeonName { get; set; }
        public long? SurgeryYear { get; set; }
        public string SurgeryNotes { get; set; }
        public long PatientId { get; set; }
    }
}
