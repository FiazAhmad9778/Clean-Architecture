using iHakeem.Application.Doctors.WorkExperience.Contracts;
using MediatR;

namespace iHakeem.Application.Doctors.WorkExperience.QueryHandler.Detail
{
    public class DoctorWorkExperienceDetailRequestDTO : IRequest<DoctorWorkExperienceDTO>
    {
        public int Id { get; set; }
    }
}
