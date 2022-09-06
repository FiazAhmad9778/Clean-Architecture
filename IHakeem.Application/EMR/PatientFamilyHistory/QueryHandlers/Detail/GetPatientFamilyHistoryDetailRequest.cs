using iHakeem.Application.EMR.PatientFamilyHistory.Contracts;
using MediatR;

namespace iHakeem.Application.EMR.PatientFamilyHistory.QueryHandlers.Detail
{
    public class GetPatientFamilyHistoryRequestDTO : IRequest<PatientFamilyHistoryResponseDTO>
    {
        public long Id { get; set; }
    }
}
