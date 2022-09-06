using iHakeem.Application.Doctors.SocialInfo.Contracts;
using iHakeem.Application.Patients.SocialInfo.Contracts;
using MediatR;
using System.Collections.Generic;

namespace iHakeem.Application.Patients.PatientSocialInfo.QueryHandler.List
{
    public class PatientSocialInfoListRequestDTO : IRequest<List<PatientSocialInfoDTO>>
    {
        public long DoctorId { get; set; }
    }
}
