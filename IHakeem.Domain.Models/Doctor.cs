using iHakeem.SharedKernal.BaseDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace iHakeem.Domain.Models
{
    public class Doctor : AuditEntity<long>
    {
        public Doctor()
        {
        }
        public long UserId { get; set; }
        public string MaritialStatusId { get; set; }
        public string MiddleName { get; set; }
        public string HomePhoneNumber { get; set; }
        public string CellNumber { get; set; }
        public string FaxNumber { get; set; }
        public string SecondaryEmail { get; set; }
        public string PracticeAddress { get; set; }
        public string PracticeCountry { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string MyIntroduction { get; set; }
        public DateTime DateOfBirth { get; set; }
        public LookupData MaritialStatus { get; set; }
        public ApplicationUser User { get; set; }
        public virtual ICollection<DoctorSocialInfo> SocialInformation { get; set; }
        public virtual ICollection<DoctorSkillsAndTraining> DoctorSkillsAndTraining { get; set; }
        public virtual ICollection<DoctorEducation> DoctorEducation { get; set; }
        public virtual ICollection<DoctorWorkExperience> DoctorWorkExperience { get; set; }
        public virtual ICollection<DoctorReference> DoctorReference { get; set; }
        public virtual ICollection<DoctorMembership> DoctorMembership { get; set; }
        public virtual ICollection<DoctorAwardsAndRecognition> DoctorAwardsAndRecognition { get; set; }
        public virtual ICollection<DoctorLicenseAndCertification> DoctorLicenseAndCertification { get; set; }
    }
}
