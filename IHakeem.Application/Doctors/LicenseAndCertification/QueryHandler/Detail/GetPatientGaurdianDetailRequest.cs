using iHakeem.Application.Doctors.Education.Contracts;
using MediatR;

namespace iHakeem.Application.Doctors.LicenseAndCertification.QueryHandler.Detail
{
    public class DoctorLicenseAndCertificationDetailRequestDTO : IRequest<DoctorLicenseAndCertificationDTO>
    {
        public int Id { get; set; }
    }
}
