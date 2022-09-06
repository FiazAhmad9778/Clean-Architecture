using System;

namespace iHakeem.Application.Doctors.Education.Contracts
{
    public class DoctorEducationDTO
    {
        public int Id { get; set; }
        public string EducationTypeId { get; set; }
        public long DoctorId { get; set; }
        public string DegreeName { get; set; }
        public bool IsCompleted { get; set; }
        public string Institute { get; set; }
        public string Majors { get; set; }
        public string DegreeDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
    }
}
