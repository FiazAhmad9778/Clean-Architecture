using iHakeem.Application.Doctors.WorkExperience.Contracts;
using MediatR;
using System.Collections.Generic;

namespace iHakeem.Application.Doctors.WorkExperience.QueryHandler.List
{
    public class DoctorWorkExperienceListRequestDTO : IRequest<List<DoctorWorkExperienceDTO>>
    {
        public long DoctorId { get; set; }
    }
}
