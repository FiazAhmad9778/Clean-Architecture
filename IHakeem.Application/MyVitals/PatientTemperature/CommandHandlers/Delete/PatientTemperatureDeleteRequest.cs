using MediatR;

namespace iHakeem.Application.MyVitals.PatientTemperature.CommandHandlers.Delete
{
    public class PatientTemperatureDeleteRequestDTO : IRequest<bool>
    {
        public long Id { get; set; }
    }
}
