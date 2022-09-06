using iHakeem.Application.Doctors.Education.Contracts;
using MediatR;
using System;
using System.Collections.Generic;

namespace iHakeem.Application.Doctors.LicenseAndCertification.CommadHandler.Create
{
    public class DoctorLicenseAndCertificationCreateRequestDTO : IRequest<DoctorLicenseAndCertificationDTO>
    {
        public int Id { get; set; }
        public long DoctorId { get; set; }

        public string LicenseOrCertificateNo { get; set; }
        public string LicenseOrCertificateTypeId { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime DateOfExpiry { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }

    }
}
