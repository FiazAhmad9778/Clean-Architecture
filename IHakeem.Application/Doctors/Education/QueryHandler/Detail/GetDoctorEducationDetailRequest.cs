using iHakeem.Application.Doctors.Education.Contracts;
using MediatR;

namespace iHakeem.Application.Doctors.Education.QueryHandler.Detail
{
    public class DoctorEducationDetailRequestDTO : IRequest<DoctorEducationDTO>
    {
        public int Id { get; set; }
    }
}
