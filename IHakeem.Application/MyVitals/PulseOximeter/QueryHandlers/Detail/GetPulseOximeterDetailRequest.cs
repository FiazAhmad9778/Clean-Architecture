using iHakeem.Application.MyVitals.PulseOximeter.Contracts;
using MediatR;

namespace iHakeem.Application.MyVitals.PulseOximeter.QueryHandlers.Detail
{
    public class GetPulseOximeterRequestDTO : IRequest<PulseOximeterResponseDTO>
    {
        public long Id { get; set; }
    }
}
