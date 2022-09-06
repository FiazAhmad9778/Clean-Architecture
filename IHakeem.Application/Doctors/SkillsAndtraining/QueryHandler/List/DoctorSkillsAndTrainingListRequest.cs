using iHakeem.Application.Doctors.SkillsAndtraining.Contracts;
using MediatR;
using System.Collections.Generic;

namespace iHakeem.Application.Doctors.SkillsAndtraining.QueryHandler.List
{
    public class DoctorSkillsAndTrainingListRequestDTO : IRequest<List<DoctorSkillsAndTrainingDTO>>
    {
        public long DoctorId { get; set; }
    }
}
