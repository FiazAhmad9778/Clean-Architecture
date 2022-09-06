using iHakeem.SharedKernal.BaseDomain;
using System;

namespace iHakeem.Application.EMR.RecreationalDrugsHistory.Contracts
{
    public class RecreationalDrugsHistoryResponseDTO : AuditEntity<long>
    {
        public long DrugId { get; set; }
        public string Type { get; set; }
        public Nullable<long> AmountPerWeek { get; set; }
        public Nullable<long> LastUsed { get; set; }
        public string RecreationalDrugsHistoryNotes { get; set; }
        public long PatientId { get; set; }
    }
}
