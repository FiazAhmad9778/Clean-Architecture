using iHakeem.Application.Doctors.AwardsAndRecognition.Contracts;
using iHakeem.Application.Patients.PersonalInfo.Contracts;
using MediatR;
using System.Collections.Generic;

namespace iHakeem.Application.Doctors.AwardsAndRecognitions.QueryHandler.List
{
    public class DoctorAwardsAndRecognitionListRequestDTO : IRequest<List<DoctorAwardsAndRecognitionDTO>>
    {
        public long DoctorId { get; set; }
    }
}
