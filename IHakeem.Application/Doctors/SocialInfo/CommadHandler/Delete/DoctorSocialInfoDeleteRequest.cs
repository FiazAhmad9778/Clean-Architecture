using MediatR;

namespace iHakeem.Application.Doctors.SocialInfo.CommadHandler.Delete
{
    public class DoctorSocialInfoDeleteRequestDTO : IRequest<bool>
    {
        public long Id { get; set; }
    }
}
