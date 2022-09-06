using iHakeem.Application.Doctors.SocialInfo.Contracts;
using MediatR;

namespace iHakeem.Application.Doctors.SocialInfo.CommadHandler.Create
{
    public class DoctorSocialInfoCreateRequestDTO : IRequest<DoctorSocialInfoDTO>
    {
        public long DoctorId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

    }
}
