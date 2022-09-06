using iHakeem.Application.EMR.SurgicalHistory.Contracts;
using MediatR;

namespace iHakeem.Application.Patients.PatientGaurdians.CommandHandlers.Delete
{
    public class PatientGaurdianDeleteRequestDTO : IRequest<bool>
    {
        public long Id { get; set; }
    }
}
