using iHakeem.Application.MyVitals.PatientTemperature.Contracts;
using MediatR;

namespace iHakeem.Application.MyVitals.PatientTemperature.QueryHandlers.Detail
{
    public class GetPatientTemperatureRequestDTO : IRequest<PatientTemperatureResponseDTO>
    {
        public long Id { get; set; }
    }
}
