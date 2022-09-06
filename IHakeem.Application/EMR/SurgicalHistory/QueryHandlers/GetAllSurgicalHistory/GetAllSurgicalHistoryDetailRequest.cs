


using iHakeem.Application.EMR.SurgicalHistory.Contracts;
using MediatR;
using System.Collections.Generic;

namespace iHakeem.Application.EMR.SurgicalHistory.QueryHandlers.Detail
{
    public class GetAllSurgicalHistoryDetailRequestDTO : IRequest<List<SurgicalHistoryResponseDTO>>
    {
    }
}
