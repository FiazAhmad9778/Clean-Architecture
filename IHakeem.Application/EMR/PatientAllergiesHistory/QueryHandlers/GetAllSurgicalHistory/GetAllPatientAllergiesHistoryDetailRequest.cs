


using iHakeem.Application.EMR.PatientAllergiesHistory.Contracts;
using MediatR;
using System.Collections.Generic;

namespace iHakeem.Application.EMR.PatientAllergiesHistory.QueryHandlers.Detail
{
    public class GetAllPatientAllergiesHistoryDetailRequestDTO : IRequest<List<PatientAllergiesHistoryResponseDTO>>
    {
    }
}
