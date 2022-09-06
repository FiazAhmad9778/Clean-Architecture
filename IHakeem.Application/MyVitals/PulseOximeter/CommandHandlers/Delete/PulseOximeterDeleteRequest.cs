using MediatR;

namespace iHakeem.Application.MyVitals.PulseOximeter.CommandHandlers.Delete
{
    public class PulseOximeterDeleteRequestDTO : IRequest<bool>
    {
        public long Id { get; set; }
    }
}
