using iHakeem.Application.MyVitals.VitalsPatientHistory.Contracts;
using MediatR;
using System.Collections.Generic;

namespace iHakeem.Application.MyVitals.VitalsPatientHistory.QueryHandlers.Detail
{
    public class GetAllVitalsPatientHistoryDetailRequestDTO : IRequest<VitalsPatientHistoryResponseDTO>
    {
    }
}
