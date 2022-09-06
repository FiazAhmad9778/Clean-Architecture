using iHakeem.Application.Doctors.DoctorServices.Contracts;
using MediatR;
using System.Collections.Generic;

namespace iHakeem.Application.Doctors.DoctorServices.CommadHandler.Create
{
    public class DoctorServiceCreateRequestDTO : IRequest<DoctorServiceDTO>
    {
        public int Id { get; set; }
        public long DoctorId { get; set; }
        public string ServiceId { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

    }
}
