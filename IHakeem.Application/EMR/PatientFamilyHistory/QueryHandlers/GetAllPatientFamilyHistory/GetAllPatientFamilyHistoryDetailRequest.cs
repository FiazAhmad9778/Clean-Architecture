


using iHakeem.Application.EMR.PatientFamilyHistory.Contracts;
using MediatR;
using System.Collections.Generic;

namespace iHakeem.Application.EMR.PatientFamilyHistory.QueryHandlers.Detail
{
    public class GetAllPatientFamilyHistoryDetailRequestDTO : IRequest<List<PatientFamilyHistoryResponseDTO>>
    {
    }
}
