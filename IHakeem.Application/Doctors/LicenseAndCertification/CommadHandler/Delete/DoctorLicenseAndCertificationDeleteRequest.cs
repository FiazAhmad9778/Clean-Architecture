using MediatR;

namespace iHakeem.Application.Doctors.LicenseAndCertification.CommadHandler.Delete
{
    public class DoctorLicenseAndCertificationDeleteRequestDTO : IRequest<bool>
    {
        public long Id { get; set; }
    }
}
