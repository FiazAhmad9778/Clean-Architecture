using iHakeem.Application.Doctors.Memberships.Contracts;
using MediatR;
using System;
using System.Collections.Generic;

namespace iHakeem.Application.Doctors.Memberships.CommadHandler.Create
{
    public class DoctorMembershipCreateRequestDTO : IRequest<DoctorMembershipDTO>
    {
        public int Id { get; set; }
        public long DoctorId { get; set; }
        public string Designation { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public bool CurrentlyMember { get; set; }

    }
}
