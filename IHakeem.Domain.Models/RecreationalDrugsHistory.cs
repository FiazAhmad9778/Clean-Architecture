using System;
using System.Collections.Generic;
using iHakeem.SharedKernal.BaseDomain;

namespace iHakeem.Domain.Models
{
    public class RecreationalDrugsHistory : AuditEntity<long>
    {
        public RecreationalDrugsHistory()
        {
        }
        public long DrugId { get; set; }
        public string Type { get; set; }
        public long? AmountPerWeek { get; set; }
        public long? LastUsed { get; set; }
        public string RecreationalDrugsHistoryNotes { get; set; }
        public long PatientId { get; set; }
        public Patient PatientDetails { get; set; }
    }
}
