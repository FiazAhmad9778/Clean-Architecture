using System;

namespace iHakeem.Application.Doctors.AwardsAndRecognition.Contracts
{
    public class DoctorAwardsAndRecognitionDTO
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
