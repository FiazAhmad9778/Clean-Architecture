using iHakeem.SharedKernal.BaseDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace iHakeem.Domain.Models
{
    public class DoctorMembership
    : DeleteEntity<int>
    {
        public long DoctorId { get; set; }
        public string Designation { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public bool CurrentlyMember { get; set; }
        public Doctor Doctor { get; set; }
    }
}
