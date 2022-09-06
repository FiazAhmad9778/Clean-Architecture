using iHakeem.Application.Doctors.SocialInfo.Contracts;
using iHakeem.Application.Patients.SocialInfo.Contracts;
using MediatR;

namespace iHakeem.Application.Patients.SocialInfo.QueryHandler.Detail
{
    public class PatientSocialInfoDetailRequestDTO : IRequest<PatientSocialInfoDTO>
    {
        public int Id { get; set; }
    }
}
