using MediatR;

namespace iHakeem.Application.Doctors.SkillsAndtraining.CommadHandler.Delete
{
    public class DoctorSkillsAndTrainingDeleteRequestDTO : IRequest<bool>
    {
        public long Id { get; set; }
    }
}
