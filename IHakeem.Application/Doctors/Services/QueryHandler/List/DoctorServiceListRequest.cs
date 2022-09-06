using iHakeem.Application.Doctors.SkillsAndtraining.Contracts;
using MediatR;
using System.Collections.Generic;
using iHakeem.Application.Doctors.DoctorServices.Contracts;

namespace iHakeem.Application.Doctors.Services.QueryHandler.List
{
    public class DoctorServiceListRequestDTO : IRequest<List<DoctorServiceDTO>>
    {
        public long DoctorId { get; set; }
    }
}
