using iHakeem.Application.Doctors.Education.Contracts;
using MediatR;
using System.Collections.Generic;

namespace iHakeem.Application.Doctors.LicenseAndCertification.QueryHandler.List
{
    public class DoctorLicenseAndCertificationListRequestDTO : IRequest<List<DoctorLicenseAndCertificationDTO>>
    {
        public long DoctorId { get; set; }

    }
}
