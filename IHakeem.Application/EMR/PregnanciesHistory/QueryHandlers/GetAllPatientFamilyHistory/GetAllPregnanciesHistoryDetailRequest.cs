


using iHakeem.Application.EMR.PregnanciesHistory.Contracts;
using MediatR;
using System.Collections.Generic;

namespace iHakeem.Application.EMR.PregnanciesHistory.QueryHandlers.Detail
{
    public class GetAllPregnanciesHistoryDetailRequestDTO : IRequest<List<PregnanciesHistoryResponseDTO>>
    {
    }
}
