using MediatR;

namespace iHakeem.Application.MyVitals.PatientWeight.CommandHandlers.Delete
{
    public class PatientWeightDeleteRequestDTO : IRequest<bool>
    {
        public long Id { get; set; }
    }
}
