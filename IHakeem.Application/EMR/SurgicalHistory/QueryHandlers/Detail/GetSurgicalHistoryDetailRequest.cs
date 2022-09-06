using iHakeem.Application.EMR.SurgicalHistory.Contracts;
using MediatR;

namespace iHakeem.Application.EMR.SurgicalHistory.QueryHandlers.Detail
{
    public class GetSurgicalHistoryRequestDTO : IRequest<SurgicalHistoryResponseDTO>
    {
        public long Id { get; set; }
    }
}
