using iHakeem.Application.EMR.MyPhysicians.Contracts;
using MediatR;

namespace iHakeem.Application.EMR.MyPhysicians.QueryHandlers.Detail
{
    public class GetMyPhysiciansRequestDTO : IRequest<MyPhysiciansResponseDTO>
    {
        public long Id { get; set; }
    }
}
