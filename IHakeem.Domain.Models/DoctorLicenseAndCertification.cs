using iHakeem.SharedKernal.BaseDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace iHakeem.Domain.Models
{
    public class DoctorLicenseAndCertification : DeleteEntity<int>
    {
        public long DoctorId { get; set; }

        public string LicenseOrCertificateNo { get; set; }
        public string LicenseOrCertificateTypeId { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime DateOfExpiry { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }

        public LookupData LicenseOrCertificateType { get; set; }
        public Doctor Doctor { get; set; }

    }
}
