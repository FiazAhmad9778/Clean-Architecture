using iHakeem.Application.EMR.SurgicalHistory.Contracts;
using MediatR;

namespace iHakeem.Application.Doctors.WorkExperience.CommadHandler.Delete
{
    public class DoctorWorkExperienceDeleteRequestDTO : IRequest<bool>
    {
        public long Id { get; set; }
    }
}
