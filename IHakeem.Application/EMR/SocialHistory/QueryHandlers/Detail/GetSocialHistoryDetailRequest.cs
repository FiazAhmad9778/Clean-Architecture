using iHakeem.Application.EMR.SocialHistory.Contracts;
using MediatR;

namespace iHakeem.Application.EMR.SocialHistory.QueryHandlers.Detail
{
    public class GetSocialHistoryRequestDTO : IRequest<SocialHistoryResponseDTO>
    {
        public long Id { get; set; }
    }
}
