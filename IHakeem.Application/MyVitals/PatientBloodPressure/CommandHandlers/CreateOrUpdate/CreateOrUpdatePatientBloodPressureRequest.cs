using iHakeem.Application.MyVitals.PatientBloodPressure.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace iHakeem.Application.MyVitals.PatientBloodPressure.CommandHandlers.CreateOrUpdate
{
    public class CreateOrUpdatePatientBloodPressureRequestDTO : IRequest<PatientBloodPressureResponseDTO>
    {
        public long Id { get; set; }
        public long Systolic { get; set; }
        public long Diastolic { get; set; }
        public DateTime BloodPressureDateAndTime { get; set; }
    }
}
