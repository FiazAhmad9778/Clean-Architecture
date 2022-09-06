using MediatR;

namespace iHakeem.Application.Doctors.Education.CommadHandler.Delete
{
    public class DoctorEducationDeleteRequestDTO : IRequest<bool>
    {
        public long Id { get; set; }
    }
}
