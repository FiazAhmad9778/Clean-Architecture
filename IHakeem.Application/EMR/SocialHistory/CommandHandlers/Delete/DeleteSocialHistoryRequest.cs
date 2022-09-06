using iHakeem.Application.EMR.SocialHistory.Contracts;
using MediatR;

namespace iHakeem.Application.EMR.SocialHistory.CommandHandlers.Delete
{
    public class DeleteSocialHistoryRequestDTO : IRequest<bool>
    {
        public long Id { get; set; }
    }
}
