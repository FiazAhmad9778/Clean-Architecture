using System.Collections.Generic;
using iHakeem.SharedKernal.BaseDomain;

namespace iHakeem.Domain.Models
{
    public class PatientFamilyHistory : AuditEntity<long>
    {
        public PatientFamilyHistory()
        {
        }
        public long RelationId { get; set; }
        public string DeceasedOrDeathAge { get; set; }
        public string MedicalConditionsOrCauseOfDeath { get; set; }
        public string Note { get; set; }
        public long PatientId { get; set; }
        public Patient PatientDetails { get; set; }
    }
}
