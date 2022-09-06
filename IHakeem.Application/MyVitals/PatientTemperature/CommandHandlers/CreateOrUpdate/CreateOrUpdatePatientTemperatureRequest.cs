using iHakeem.Application.MyVitals.PatientTemperature.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace iHakeem.Application.MyVitals.PatientTemperature.CommandHandlers.CreateOrUpdate
{
    public class CreateOrUpdatePatientTemperatureRequestDTO : IRequest<PatientTemperatureResponseDTO>
    {
        public long Id { get; set; }
        public float Temperature { get; set; }
        public long UnitId { get; set; }
        public DateTime PatientTemperatureDateAndTime { get; set; }
    }
}
