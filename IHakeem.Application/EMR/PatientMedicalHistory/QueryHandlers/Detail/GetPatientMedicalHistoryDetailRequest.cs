using iHakeem.Application.EMR.PatientMedicalHistory.Contracts;
using MediatR;

namespace iHakeem.Application.EMR.PatientMedicalHistory.QueryHandlers.Detail
{
    public class GetPatientMedicalHistoryRequestDTO : IRequest<PatientMedicalHistoryResponseDTO>
    {
        public long Id { get; set; }
    }
}
