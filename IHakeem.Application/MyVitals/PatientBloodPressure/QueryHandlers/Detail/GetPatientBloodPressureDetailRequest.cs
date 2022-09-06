using iHakeem.Application.MyVitals.PatientBloodPressure.Contracts;
using MediatR;

namespace iHakeem.Application.MyVitals.PatientBloodPressure.QueryHandlers.Detail
{
    public class GetPatientBloodPressureRequestDTO : IRequest<PatientBloodPressureResponseDTO>
    {
        public long Id { get; set; }
    }
}
