using iHakeem.Application.EMR.SurgicalHistory.Contracts;
using MediatR;

namespace iHakeem.Application.EMR.DetailPregnancies.CommandHandlers.Delete
{
    public class DetailPregnanciesDeleteRequestDTO : IRequest<bool>
    {
        public long Id { get; set; }
    }
}
