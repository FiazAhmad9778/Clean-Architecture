using iHakeem.Application.MyVitals.PulseOximeter.Contracts;
using MediatR;
using System.Collections.Generic;

namespace iHakeem.Application.MyVitals.PulseOximeter.QueryHandlers.Detail
{
    public class GetAllPulseOximeterDetailRequestDTO : IRequest<List<PulseOximeterResponseDTO>>
    {
    }
}
