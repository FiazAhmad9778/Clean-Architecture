using iHakeem.Application.EMR.CurrentMedication.Contracts;
using MediatR;
using System.Collections.Generic;

namespace iHakeem.Application.EMR.CurrentMedication.QueryHandlers.Detail
{
    public class GetAllCurrentMedicationDetailRequestDTO : IRequest<List<CurrentMedicationResponseDTO>>
    {
    }
}
