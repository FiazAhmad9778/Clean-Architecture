using iHakeem.Application.EMR.MyPhysicians.Contracts;
using MediatR;

namespace iHakeem.Application.EMR.MyPhysicians.CommandHandlers.Delete
{
    public class DeleteMyPhysiciansRequestDTO : IRequest<bool>
    {
        public long Id { get; set; }
    }
}
