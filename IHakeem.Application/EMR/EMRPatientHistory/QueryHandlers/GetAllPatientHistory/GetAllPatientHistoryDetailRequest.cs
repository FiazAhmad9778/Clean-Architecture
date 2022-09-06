using iHakeem.Application.EMR.EMRPatientHistory.Contracts;
using MediatR;
using System.Collections.Generic;

namespace iHakeem.Application.EMR.EMRPatientHistory.QueryHandlers.Detail
{
    public class GetAllPatientHistoryDetailRequestDTO : IRequest<EMRPatientHistoryResponseDTO>
    {
    }
}
