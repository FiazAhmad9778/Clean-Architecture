using iHakeem.SharedKernal.BaseDomain;
using System;

namespace iHakeem.Application.EMR.PatientAllergiesHistory.Contracts
{
    public class PatientAllergiesHistoryResponseDTO : AuditEntity<long>
    {
        public string AllergyTo { get; set; }
        public string Reaction { get; set; }
        public string AllergyNotes { get; set; }
        public long PatientId { get; set; }
    }
}
