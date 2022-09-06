using iHakeem.Application.MyVitals.PatientWeight.Contracts;
using MediatR;

namespace iHakeem.Application.MyVitals.PatientWeight.QueryHandlers.Detail
{
    public class GetPatientWeightRequestDTO : IRequest<PatientWeightResponseDTO>
    {
        public long Id { get; set; }
    }
}
