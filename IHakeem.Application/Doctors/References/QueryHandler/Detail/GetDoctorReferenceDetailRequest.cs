using iHakeem.Application.Doctors.References.Contracts;
using MediatR;

namespace iHakeem.Application.Doctors.References.QueryHandler.Detail
{
    public class DoctorReferenceDetailRequestDTO : IRequest<DoctorReferenceDTO>
    {
        public int Id { get; set; }
    }
}
