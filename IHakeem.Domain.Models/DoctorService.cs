using iHakeem.SharedKernal.BaseDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace iHakeem.Domain.Models
{
    public class DoctorService : DeleteEntity<int>
    {
        public long DoctorId { get; set; }
        public string ServiceId { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        public LookupData Service { get; set; }
    }
}
