using iHakeem.Application.EMR.PatientAllergiesHistory.Contracts;
using MediatR;

namespace iHakeem.Application.EMR.PatientAllergiesHistory.QueryHandlers.Detail
{
    public class GetPatientAllergiesHistoryRequestDTO : IRequest<PatientAllergiesHistoryResponseDTO>
    {
        public long Id { get; set; }
    }
}
