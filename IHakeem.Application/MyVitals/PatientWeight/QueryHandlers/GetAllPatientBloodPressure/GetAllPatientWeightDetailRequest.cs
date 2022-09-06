using iHakeem.Application.MyVitals.PatientWeight.Contracts;
using MediatR;
using System.Collections.Generic;

namespace iHakeem.Application.MyVitals.PatientWeight.QueryHandlers.Detail
{
    public class GetAllPatientWeightDetailRequestDTO : IRequest<List<PatientWeightResponseDTO>>
    {
    }
}
