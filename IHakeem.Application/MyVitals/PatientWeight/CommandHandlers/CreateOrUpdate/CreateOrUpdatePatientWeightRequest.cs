using iHakeem.Application.MyVitals.PatientWeight.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace iHakeem.Application.MyVitals.PatientWeight.CommandHandlers.CreateOrUpdate
{
    public class CreateOrUpdatePatientWeightRequestDTO : IRequest<PatientWeightResponseDTO>
    {
        public long Id { get; set; }
        public float Weight { get; set; }
        public long UnitId { get; set; }
        public DateTime PatientWeightDateAndTime { get; set; }
    }
}
