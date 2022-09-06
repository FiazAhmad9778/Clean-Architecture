using iHakeem.Application.EMR.PatientAllergiesHistory.Contracts;
using MediatR;

namespace iHakeem.Application.EMR.PatientAllergiesHistory.CommandHandlers.Delete
{
    public class DeletePatientAllergiesHistoryRequestDTO : IRequest<bool>
    {
        public long Id { get; set; }
    }
}
