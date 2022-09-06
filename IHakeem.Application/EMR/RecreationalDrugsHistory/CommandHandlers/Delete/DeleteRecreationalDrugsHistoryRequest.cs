using iHakeem.Application.EMR.RecreationalDrugsHistory.Contracts;
using MediatR;

namespace iHakeem.Application.EMR.RecreationalDrugsHistory.CommandHandlers.Delete
{
    public class DeleteRecreationalDrugsHistoryRequestDTO : IRequest<bool>
    {
        public long Id { get; set; }
    }
}
