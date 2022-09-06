using iHakeem.Application.Patients.EmergencyContact.Contracts;
using iHakeem.Application.Patients.PersonalInfo.Contracts;
using MediatR;
using System.Collections.Generic;

namespace iHakeem.Application.Patients.EmergencyContact.QueryHandler.List
{
    public class PatientEmergencyContactListRequestDTO : IRequest<List<PatientEmergencyContactDTO>>
    {
        public long DoctorId { get; set; }
    }
}
