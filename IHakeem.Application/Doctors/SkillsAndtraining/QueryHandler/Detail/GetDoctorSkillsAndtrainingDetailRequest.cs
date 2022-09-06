using iHakeem.Application.Doctors.SkillsAndtraining.Contracts;
using MediatR;

namespace iHakeem.Application.Doctors.SkillsAndtraining.QueryHandler.Detail
{
    public class DoctorSkillsAndtrainingDetailRequestDTO : IRequest<DoctorSkillsAndTrainingDTO>
    {
        public int Id { get; set; }
    }
}
