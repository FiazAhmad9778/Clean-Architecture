using iHakeem.Application.MyVitals.PatientTemperature.Contracts;
using MediatR;
using System.Collections.Generic;

namespace iHakeem.Application.MyVitals.PatientTemperature.QueryHandlers.Detail
{
    public class GetAllPatientTemperatureDetailRequestDTO : IRequest<List<PatientTemperatureResponseDTO>>
    {
    }
}
