using iHakeem.Application.Doctors.References.Contracts;
using iHakeem.Application.Patients.PersonalInfo.Contracts;
using MediatR;
using System.Collections.Generic;

namespace iHakeem.Application.Doctors.References.QueryHandler.List
{
    public class DoctorReferenceListRequestDTO : IRequest<List<DoctorReferenceDTO>>
    {
        public long DoctorId { get; set; }

    }
}
