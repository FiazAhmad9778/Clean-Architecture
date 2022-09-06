using iHakeem.Application.EMR.PatientFamilyHistory.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace iHakeem.Application.EMR.PatientFamilyHistory.CommandHandlers.CreateOrUpdate
{
    public class CreateOrUpdatePatientFamilyHistoryRequestDTO : IRequest<PatientFamilyHistoryResponseDTO>
    {
        public long Id { get; set; }
        public long RelationId { get; set; }
        public string DeceasedOrDeathAge { get; set; }
        public string MedicalConditionsOrCauseOfDeath { get; set; }
        public string Note { get; set; }
    }
}
