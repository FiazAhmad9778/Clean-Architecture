using iHakeem.SharedKernal.BaseDomain;
using System;

namespace iHakeem.Application.EMR.PharmacyInformation.Contracts
{
    public class PharmacyInformationResponseDTO : AuditEntity<long>
    {
        public string PharmacyName { get; set; }
        public string PharmacyAddress { get; set; }
        public long? CountryId { get; set; }
        public long? StateId { get; set; }
        public long? CityId { get; set; }
        public string PhoneNumber { get; set; }
        public string Fax { get; set; }
        public long PatientId { get; set; }
    }
}
