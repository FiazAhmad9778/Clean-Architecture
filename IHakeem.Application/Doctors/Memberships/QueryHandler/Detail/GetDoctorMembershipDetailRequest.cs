using iHakeem.Application.Doctors.Memberships.Contracts;
using MediatR;

namespace iHakeem.Application.Doctors.Memberships.QueryHandler.Detail
{
    public class DoctorMembershipDetailRequestDTO : IRequest<DoctorMembershipDTO>
    {
        public int Id { get; set; }
    }
}
