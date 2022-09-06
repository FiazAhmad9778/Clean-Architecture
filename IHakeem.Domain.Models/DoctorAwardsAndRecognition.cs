using iHakeem.SharedKernal.BaseDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace iHakeem.Domain.Models
{
    public class DoctorAwardsAndRecognition : DeleteEntity<int>
    {
        public long DoctorId { get; set; }
        public string Title { get; set; }
        public string Institute { get; set; }
        public DateTime AwardDate { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }

        public Doctor Doctor { get; set; }
    }
}
