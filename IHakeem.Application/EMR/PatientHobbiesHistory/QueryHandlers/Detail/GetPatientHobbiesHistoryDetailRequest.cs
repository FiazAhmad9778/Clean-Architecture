using iHakeem.Application.EMR.PatientHobbiesHistory.Contracts;
using MediatR;

namespace iHakeem.Application.EMR.PatientHobbiesHistory.QueryHandlers.Detail
{
    public class GetPatientHobbiesHistoryRequestDTO : IRequest<PatientHobbiesHistoryResponseDTO>
    {
        public long Id { get; set; }
    }
}
