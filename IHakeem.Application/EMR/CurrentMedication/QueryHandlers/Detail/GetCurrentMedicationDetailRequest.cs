using iHakeem.Application.EMR.CurrentMedication.Contracts;
using MediatR;

namespace iHakeem.Application.EMR.CurrentMedication.QueryHandlers.Detail
{
    public class GetCurrentMedicationDetailRequestDTO : IRequest<CurrentMedicationResponseDTO>
    {
        public long Id { get; set; }
    }
}
