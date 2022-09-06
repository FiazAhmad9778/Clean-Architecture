using iHakeem.Application.Doctors.AwardsAndRecognition.Contracts;
using MediatR;
using System;
using System.Collections.Generic;

namespace iHakeem.Application.Doctors.DoctorAwardsAndRecognitions.CommadHandler.Create
{
    public class DoctorAwardsAndRecognitionCreateRequestDTO : IRequest<DoctorAwardsAndRecognitionDTO>
    {
        public int Id { get; set; }
        public long DoctorId { get; set; }
        public string Title { get; set; }
        public string Institute { get; set; }
        public DateTime AwardDate { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }

    }
}
