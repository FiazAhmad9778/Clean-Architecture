using iHakeem.Application.Patients.PatientGaurdians.Contracts;
using MediatR;

namespace iHakeem.Application.Patients.PatientGaurdians.QueryHandlers.Detail
{
    public class GetPatientGaurdianRequestDTO : IRequest<PatientGaurdianResponseDTO>
    {
        public long Id { get; set; }
    }
}
