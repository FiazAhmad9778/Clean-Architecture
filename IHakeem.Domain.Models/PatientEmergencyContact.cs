using iHakeem.SharedKernal.BaseDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace iHakeem.Domain.Models
{
    public class PatientEmergencyContact : DeleteEntity<int>
    {
        public long PatientId { get; set; }
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
        public string RelationId { get; set; }
        public LookupData Relation { get; set; }
        public Patient Patient { get; set; }
    }
}
