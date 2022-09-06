using MediatR;

namespace iHakeem.Application.MyVitals.PatientBloodPressure.CommandHandlers.Delete
{
    public class PatientBloodPressureDeleteRequestDTO : IRequest<bool>
    {
        public long Id { get; set; }
    }
}
