using System;
using System.Collections.Generic;
using iHakeem.SharedKernal.BaseDomain;

namespace iHakeem.Domain.Models
{
    public class PatientHobbiesHistory : AuditEntity<long>
    {
        public PatientHobbiesHistory()
        {
        }
        public string  Hobby { get; set; }
        public long PatientId { get; set; }
        public Patient PatientDetails { get; set; }
    }
}
