using MediatR;

namespace iHakeem.Application.Patients.PatientEmergencyContacts.CommandHandlers.Delete
{
    public class PatientEmergencyContactDeleteRequestDTO : IRequest<bool>
    {
        public long Id { get; set; }
    }
}
