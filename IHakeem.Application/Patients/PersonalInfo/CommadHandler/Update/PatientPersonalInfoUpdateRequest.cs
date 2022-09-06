using iHakeem.Application.Patients.PersonalInfo.Contracts;
using MediatR;

namespace iHakeem.Application.Patients.PersonalInfo.CommadHandler.Update
{
    public class PatientPersonalInfoUpdateRequestDTO : IRequest<PatientPersonalInfoResponseDTO>
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MaritialStatusId { get; set; }
        public string PreferedLanguageId { get; set; }
        public string TitleId { get; set; }
        public string GenderId { get; set; }
        public string EthnicityId { get; set; }
        public string BloodGroupId { get; set; }
        public string HomeContact { get; set; }
        public string WorkContact { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string PrimaryAddress { get; set; }
        public string SecondaryAddress { get; set; }
    }
}
