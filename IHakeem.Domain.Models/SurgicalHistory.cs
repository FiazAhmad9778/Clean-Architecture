using System;
using System.Collections.Generic;
using iHakeem.SharedKernal.BaseDomain;

namespace iHakeem.Domain.Models
{
    public class SurgicalHistory : AuditEntity<long>
    {
        public SurgicalHistory()
        {
        }
        public string SurgeryType { get; set; }
        public string SurgeonName { get; set; }
        public long? SurgeryYear { get; set; }
        public string SurgeryNotes { get; set; }
        public long PatientId { get; set; }
        public Patient PatientDetails { get; set; }
    }
}
