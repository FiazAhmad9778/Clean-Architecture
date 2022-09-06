using iHakeem.Application.Doctors.Memberships.Contracts;
using MediatR;
using System.Collections.Generic;

namespace iHakeem.Application.Doctors.Memberships.QueryHandler.List
{
    public class DoctorMembershipListRequestDTO : IRequest<List<DoctorMembershipDTO>>
    {
        public long DoctorId { get; set; }

    }
}
