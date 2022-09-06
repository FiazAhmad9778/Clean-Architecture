using iHakeem.Application.Doctors.SocialInfo.Contracts;
using iHakeem.Application.Patients.SocialInfo.Contracts;
using MediatR;
using System.Collections.Generic;

namespace iHakeem.Application.Patients.SocialInfo.CommadHandler.Create
{
    public class PatientSocialInfoCreateRequestDTO : IRequest<PatientSocialInfoDTO>
    {
        public long PatientId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

    }
}
