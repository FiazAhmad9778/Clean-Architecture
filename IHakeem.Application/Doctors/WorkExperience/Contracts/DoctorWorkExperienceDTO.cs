using System;

namespace iHakeem.Application.Doctors.WorkExperience.Contracts
{
    public class DoctorWorkExperienceDTO
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
