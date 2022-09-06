using iHakeem.Application.EMR.SurgicalHistory.Contracts;
using MediatR;

namespace iHakeem.Application.EMR.PatientHobbiesHistory.CommandHandlers.Delete
{
    public class PatientHobbiesHistoryDeleteRequestDTO : IRequest<bool>
    {
        public long Id { get; set; }
    }
}
