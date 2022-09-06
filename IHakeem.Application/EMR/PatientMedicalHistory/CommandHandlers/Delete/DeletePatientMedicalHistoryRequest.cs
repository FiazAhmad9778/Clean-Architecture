using iHakeem.Application.EMR.PatientMedicalHistory.Contracts;
using MediatR;

namespace iHakeem.Application.EMR.PatientMedicalHistory.CommandHandlers.Delete
{
    public class DeletePatientMedicalHistoryRequestDTO : IRequest<bool>
    {
        public long Id { get; set; }
    }
}
