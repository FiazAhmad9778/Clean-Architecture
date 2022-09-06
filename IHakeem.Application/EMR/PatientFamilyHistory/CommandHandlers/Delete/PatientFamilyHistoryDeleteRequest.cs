using iHakeem.Application.EMR.SurgicalHistory.Contracts;
using MediatR;

namespace iHakeem.Application.EMR.PatientFamilyHistory.CommandHandlers.Delete
{
    public class PatientFamilyHistoryDeleteRequestDTO : IRequest<bool>
    {
        public long Id { get; set; }
    }
}
