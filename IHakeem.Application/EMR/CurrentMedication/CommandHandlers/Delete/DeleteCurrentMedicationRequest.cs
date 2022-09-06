using iHakeem.Application.EMR.CurrentMedication.Contracts;
using MediatR;

namespace iHakeem.Application.EMR.CurrentMedication.CommandHandlers.Delete
{
    public class DeleteCurrentMedicationRequestDTO : IRequest<bool>
    {
        public long Id { get; set; }
    }
}
