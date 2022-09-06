


using iHakeem.Application.EMR.SocialHistory.Contracts;
using MediatR;
using System.Collections.Generic;

namespace iHakeem.Application.EMR.SocialHistory.QueryHandlers.Detail
{
    public class GetAllSocialHistoryDetailRequestDTO : IRequest<List<SocialHistoryResponseDTO>>
    {
    }
}
