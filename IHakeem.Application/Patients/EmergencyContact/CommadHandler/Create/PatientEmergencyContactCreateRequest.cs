using iHakeem.Application.Patients.EmergencyContact.Contracts;
using MediatR;
using System.Collections.Generic;

namespace iHakeem.Application.Patients.EmergencyContact.CommadHandler.Create
{
    public class PatientEmergencyContactCreateRequestDTO : IRequest<PatientEmergencyContactDTO>
    {
        public int Id { get; set; }
        public long PatientId { get; set; }
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
        public string RelationId { get; set; }

    }
}
