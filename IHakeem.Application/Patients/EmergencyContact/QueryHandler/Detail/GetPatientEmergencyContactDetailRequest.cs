using iHakeem.Application.Patients.EmergencyContact.Contracts;
using MediatR;

namespace iHakeem.Application.Patients.PatientEmergencyContacts.QueryHandlers.Detail
{
    public class PatientEmergencyContactDetailRequestDTO : IRequest<PatientEmergencyContactDTO>
    {
        public int Id { get; set; }
    }
}
