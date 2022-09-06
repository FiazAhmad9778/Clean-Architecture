using System;
using System.Collections.Generic;
using System.Text;

namespace iHakeem.Application.Patients.PersonalInfo.Contracts
{
    public class PatientPersonalInfoResponseDTO
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MaritialStatusId { get; set; }
        public string MaritialStatusText { get; set; }
        public string PreferedLanguageId { get; set; }
        public string PreferedLanguageText { get; set; }
        public string EthnicityId { get; set; }
        public string EthnicityText { get; set; }
        public string TitleId { get; set; }
        public string TitleText { get; set; }
        public string GenderId { get; set; }
        public string GenderText { get; set; }
        public string BloodGroupId { get; set; }
        public string BloodGroupText { get; set; }
        public string HomeContact { get; set; }
        public string WorkContact { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string PrimaryAddress { get; set; }
        public string SecondaryAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
