using iHakeem.Application.Doctors.Education.Contracts;
using iHakeem.Application.Patients.PersonalInfo.Contracts;
using MediatR;
using System.Collections.Generic;

namespace iHakeem.Application.Doctors.Education.QueryHandler.List
{
    public class DoctorEducationListRequestDTO : IRequest<List<DoctorEducationDTO>>
    {
        public long DoctorId { get; set; }

    }
}
