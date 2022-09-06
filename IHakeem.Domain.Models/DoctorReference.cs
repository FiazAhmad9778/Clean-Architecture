using iHakeem.SharedKernal.BaseDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace iHakeem.Domain.Models
{
    public class DoctorReference : DeleteEntity<int>
    {
        public long DoctorId { get; set; }
        public string RelationId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public string Fax { get; set; }
        public string DurationAssociated { get; set; }
        public LookupData Relation { get; set; }
        public Doctor Doctor { get; set; }
    }
}
