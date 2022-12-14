using iHakeem.Application.Doctors.SkillsAndtraining.Contracts;
using MediatR;
using System;
using System.Collections.Generic;

namespace iHakeem.Application.Doctors.SkillsAndtraining.CommadHandler.Create
{
    public class DoctorSkillsAndTrainingCreateRequestDTO : IRequest<DoctorSkillsAndTrainingDTO>
    {
        public int Id { get; set; }
        public string EducationTypeId { get; set; }
        public long DoctorId { get; set; }
        public string SkillName { get; set; }
        public string Institute { get; set; }
        public string SuperVisor { get; set; }
        public string SuperVisorContact { get; set; }
        public string Adress { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }

    }
}
