using iHakeem.Application.EMR.PregnanciesHistory.Contracts;
using MediatR;

namespace iHakeem.Application.EMR.PregnanciesHistory.QueryHandlers.Detail
{
    public class GetPregnanciesHistoryRequestDTO : IRequest<PregnanciesHistoryResponseDTO>
    {
        public long Id { get; set; }
    }
}
