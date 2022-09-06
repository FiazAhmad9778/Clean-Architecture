using System;
using System.Collections.Generic;
using iHakeem.SharedKernal.BaseDomain;

namespace iHakeem.Domain.Models
{
    public class PatientAllergiesHistory : AuditEntity<long>
    {
        public PatientAllergiesHistory()
        {
        }
        public string AllergyTo { get; set; }
        public string Reaction { get; set; }
        public string AllergyNotes { get; set; }
        public long PatientId { get; set; }
        public Patient PatientDetails { get; set; }
    }
}
