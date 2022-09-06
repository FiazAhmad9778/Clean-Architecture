using iHakeem.Application.Doctors.DoctorServices.Contracts;
using MediatR;

namespace iHakeem.Application.Doctors.Services.QueryHandler.Detail
{
    public class DoctorServiceDetailRequestDTO : IRequest<DoctorServiceDTO>
    {
        public int Id { get; set; }
    }
}
