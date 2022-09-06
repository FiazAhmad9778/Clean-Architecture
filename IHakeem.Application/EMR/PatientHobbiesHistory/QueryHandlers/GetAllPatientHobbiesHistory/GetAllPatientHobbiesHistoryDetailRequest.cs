


using iHakeem.Application.EMR.PatientHobbiesHistory.Contracts;
using MediatR;
using System.Collections.Generic;

namespace iHakeem.Application.EMR.PatientHobbiesHistory.QueryHandlers.Detail
{
    public class GetAllPatientHobbiesHistoryDetailRequestDTO : IRequest<List<PatientHobbiesHistoryResponseDTO>>
    {
    }
}
