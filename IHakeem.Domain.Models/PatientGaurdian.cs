using iHakeem.SharedKernal.BaseDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace iHakeem.Domain.Models
{
    public class PatientGaurdian : AuditEntity<long>
    {
        public long PatientId { get; set; }
        public string RelationId { get; set; }
        public string CellPhone { get; set; }
        public string HomeContact { get; set; }
        public string WorkContact { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string PrimaryAddress { get; set; }
        public string SecondaryAddress { get; set; }

        public LookupData Relation { get; set; }
        public Patient Patient { get; set; }
    }
}
