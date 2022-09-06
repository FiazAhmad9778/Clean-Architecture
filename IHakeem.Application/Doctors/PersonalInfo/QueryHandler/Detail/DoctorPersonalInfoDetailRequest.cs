using iHakeem.Application.Doctors.PersonalInfo.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace iHakeem.Application.Doctors.PersonalInfo.QueryHandler.Detail
{
    public class DoctorPersonalInfoDetailRequestDTO : IRequest<DoctorPersonalInfoResponseDTO>
    {
        public long DoctorId { get; set; }

    }
}
