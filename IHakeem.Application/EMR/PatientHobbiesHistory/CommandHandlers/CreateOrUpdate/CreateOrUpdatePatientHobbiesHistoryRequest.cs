
using iHakeem.Application.EMR.PatientHobbiesHistory.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace iHakeem.Application.EMR.PatientHobbiesHistory.CommandHandlers.CreateOrUpdate
{
    public class CreateOrUpdatePatientHobbiesHistoryRequestDTO : IRequest<PatientHobbiesHistoryResponseDTO>
    {
        public long Id { get; set; }
        public string Hobby { get; set; }
    }
}
