using iHakeem.Application.Doctors.SocialInfo.Contracts;
using MediatR;

namespace iHakeem.Application.Doctors.SocialInfo.QueryHandler.Detail
{
    public class DoctorSocialInfoDetailRequestDTO : IRequest<DoctorSocialInfoDTO>
    {
        public int Id { get; set; }
    }
}
