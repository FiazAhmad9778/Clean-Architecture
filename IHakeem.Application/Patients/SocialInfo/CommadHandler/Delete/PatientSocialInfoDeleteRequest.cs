using MediatR;

namespace iHakeem.Application.Patients.SocialInfo.CommadHandler.Delete
{
    public class PatientSocialInfoDeleteRequestDTO : IRequest<bool>
    {
        public long Id { get; set; }
    }
}
