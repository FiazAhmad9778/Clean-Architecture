using iHakeem.Application.Patients.PatientGaurdians.Contracts;
using MediatR;

namespace iHakeem.Application.Patients.PatientGaurdians.CommandHandlers.CreateOrUpdate
{
    public class CreateOrUpdatePatientGaurdianRequestDTO : IRequest<PatientGaurdianResponseDTO>
    {
        public long Id { get; set; }
        public long PatientId { get; set; }
        public string RelationId { get; set; }
        public string CellPhone { get; set; }
        public string HomeContact { get; set; }
        public string WorkContact { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string PrimaryAddress { get; set; }
        public string SecondaryAddress { get; set; }
    }
}
