using iHakeem.Application.EMR.SurgicalHistory.Contracts;
using MediatR;

namespace iHakeem.Application.EMR.PregnanciesHistory.CommandHandlers.Delete
{
    public class PregnanciesHistoryDeleteRequestDTO : IRequest<bool>
    {
        public long Id { get; set; }
    }
}
