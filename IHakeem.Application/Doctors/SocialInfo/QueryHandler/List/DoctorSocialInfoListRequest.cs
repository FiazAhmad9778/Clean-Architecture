using iHakeem.Application.Doctors.SocialInfo.Contracts;
using MediatR;
using System.Collections.Generic;

namespace iHakeem.Application.Doctors.SocialInfo.QueryHandler.List
{
    public class DoctorSocialInfoListRequestDTO : IRequest<List<DoctorSocialInfoDTO>>
    {
        public long DoctorId { get; set; }
    }
}
