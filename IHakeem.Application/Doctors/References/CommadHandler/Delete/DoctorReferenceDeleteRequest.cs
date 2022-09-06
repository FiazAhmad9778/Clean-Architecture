using MediatR;

namespace iHakeem.Application.Doctors.References.CommadHandler.Delete
{
    public class DoctorReferenceDeleteRequestDTO : IRequest<bool>
    {
        public long Id { get; set; }
    }
}
