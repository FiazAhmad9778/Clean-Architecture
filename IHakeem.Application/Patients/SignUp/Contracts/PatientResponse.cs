using System;
using System.Collections.Generic;
using System.Text;

namespace iHakeem.Application.Patients.SignUp.Contracts
{
    public class PatientResponseDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TitleId { get; set; }
        public string GenderId { get; set; }
        public string CountryId { get; set; }
        public string LanguageId { get; set; }
        public string Address { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
