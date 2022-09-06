using iHakeem.Application.EMR.RecreationalDrugsHistory.Contracts;
using MediatR;

namespace iHakeem.Application.EMR.RecreationalDrugsHistory.QueryHandlers.Detail
{
    public class GetRecreationalDrugsHistoryRequestDTO : IRequest<RecreationalDrugsHistoryResponseDTO>
    {
        public long Id { get; set; }
    }
}
