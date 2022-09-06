using System;
using System.Collections.Generic;
using iHakeem.SharedKernal.BaseDomain;

namespace iHakeem.Domain.Models
{
    public class PharmacyInformation : AuditEntity<long>
    {
        public PharmacyInformation()
        {
        }
        public string PharmacyName { get; set; }
        public string PharmacyAddress { get; set; }
        public long? CountryId { get; set; }
        public long? StateId { get; set; }
        public long? CityId { get; set; }
        public string PhoneNumber { get; set; }
        public string Fax { get; set; }
        public long PatientId { get; set; }
        public Patient PatientDetails { get; set; }
    }
}
