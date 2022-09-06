using iHakeem.Application.Doctors.SkillsAndtraining.Contracts;
using iHakeem.Application.Doctors.WorkExperience.Contracts;
using MediatR;
using System;
using System.Collections.Generic;

namespace iHakeem.Application.Doctors.WorkExperience.CommadHandler.Create
{
    public class DoctorWorkExperienceCreateRequestDTO : IRequest<DoctorWorkExperienceDTO>
    {
        public int Id { get; set; }
        public long DoctorId { get; set; }
        public string JobTitle { get; set; }
        public string OrgnizationName { get; set; }
        public string SuperVisor { get; set; }
        public string SuperVisorContact { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string Fax { get; set; }
        public string Address { get; set; }
        public bool ISCurrentlyWorking { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }

    }
}
