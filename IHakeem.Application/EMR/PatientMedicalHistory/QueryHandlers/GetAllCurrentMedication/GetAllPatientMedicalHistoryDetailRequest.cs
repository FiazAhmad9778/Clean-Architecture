


using iHakeem.Application.EMR.PatientMedicalHistory.Contracts;
using MediatR;
using System.Collections.Generic;

namespace iHakeem.Application.EMR.PatientMedicalHistory.QueryHandlers.Detail
{
    public class GetAllPatientMedicalHistoryDetailRequestDTO : IRequest<List<PatientMedicalHistoryResponseDTO>>
    {
    }
}
