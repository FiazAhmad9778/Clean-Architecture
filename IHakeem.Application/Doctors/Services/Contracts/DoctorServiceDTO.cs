using System;

namespace iHakeem.Application.Doctors.DoctorServices.Contracts
{
    public class DoctorServiceDTO
    {
        public int Id { get; set; }
        public long DoctorId { get; set; }
        public string ServiceId { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
