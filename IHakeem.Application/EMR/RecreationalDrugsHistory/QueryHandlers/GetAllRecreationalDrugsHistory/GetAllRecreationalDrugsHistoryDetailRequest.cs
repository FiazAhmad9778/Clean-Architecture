


using iHakeem.Application.EMR.RecreationalDrugsHistory.Contracts;
using MediatR;
using System.Collections.Generic;

namespace iHakeem.Application.EMR.RecreationalDrugsHistory.QueryHandlers.Detail
{
    public class GetAllRecreationalDrugsHistoryDetailRequestDTO : IRequest<List<RecreationalDrugsHistoryResponseDTO>>
    {
    }
}
