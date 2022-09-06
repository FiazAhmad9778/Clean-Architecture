using iHakeem.Application.EMR.SurgicalHistory.Contracts;
using MediatR;

namespace iHakeem.Application.EMR.SurgicalHistory.CommandHandlers.Delete
{
    public class DeleteSurgicalHistoryRequestDTO : IRequest<bool>
    {
        public long Id { get; set; }
    }
}
