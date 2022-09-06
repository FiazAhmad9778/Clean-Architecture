using iHakeem.Application.EMR.SurgicalHistory.Contracts;
using MediatR;

namespace iHakeem.Application.Doctors.Services.CommadHandler.Delete
{
    public class DoctorServiceDeleteRequestDTO : IRequest<bool>
    {
        public long Id { get; set; }
    }
}
