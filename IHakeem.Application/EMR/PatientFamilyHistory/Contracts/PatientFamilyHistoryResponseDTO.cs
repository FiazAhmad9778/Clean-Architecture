using iHakeem.SharedKernal.BaseDomain;
using System;

namespace iHakeem.Application.EMR.PatientFamilyHistory.Contracts
{
    public class PatientFamilyHistoryResponseDTO : AuditEntity<long>
    {
        public long RelationId { get; set; }
        public string DeceasedOrDeathAge { get; set; }
        public string MedicalConditionsOrCauseOfDeath { get; set; }
        public string Note { get; set; }
        public long PatientId { get; set; }
    }
}
