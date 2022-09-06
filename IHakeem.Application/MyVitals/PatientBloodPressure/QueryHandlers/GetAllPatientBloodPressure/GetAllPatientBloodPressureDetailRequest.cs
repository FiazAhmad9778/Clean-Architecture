using iHakeem.Application.MyVitals.PatientBloodPressure.Contracts;
using MediatR;
using System.Collections.Generic;

namespace iHakeem.Application.MyVitals.PatientBloodPressure.QueryHandlers.Detail
{
    public class GetAllPatientBloodPressureDetailRequestDTO : IRequest<List<PatientBloodPressureResponseDTO>>
    {
    }
}
