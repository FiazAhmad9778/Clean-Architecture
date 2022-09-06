using iHakeem.SharedKernal.BaseDomain;
using System;

namespace iHakeem.Domain.Models
{
    public class DoctorSkillsAndTraining : DeleteEntity<int>
    {
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
        public LookupData EducationType { get; set; }
        public Doctor Doctor { get; set; }
    }
}
