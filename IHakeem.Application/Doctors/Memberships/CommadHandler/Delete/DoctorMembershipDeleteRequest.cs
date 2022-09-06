using MediatR;

namespace iHakeem.Application.Doctors.Memberships.CommadHandler.Delete
{
    public class DoctorMembershipDeleteRequestDTO : IRequest<bool>
    {
        public long Id { get; set; }
    }
}
