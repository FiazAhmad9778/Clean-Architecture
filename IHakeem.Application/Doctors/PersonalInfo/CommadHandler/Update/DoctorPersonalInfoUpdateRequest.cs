using iHakeem.Application.Doctors.PersonalInfo.Contracts;
using MediatR;

namespace iHakeem.Application.Doctors.PersonalInfo.CommadHandler.Update
{
    public class DoctorPersonalInfoUpdateRequestDTO : IRequest<DoctorPersonalInfoResponseDTO>
    {
        public long Id { get; set; }
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
    }
}
