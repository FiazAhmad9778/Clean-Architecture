using iHakeem.Application.Doctors.AwardsAndRecognition.Contracts;
using MediatR;

namespace iHakeem.Application.Doctors.AwardsAndRecognitions.QueryHandler.Detail
{
    public class DoctorAwardsAndRecognitionDetailRequestDTO : IRequest<DoctorAwardsAndRecognitionDTO>
    {
        public int Id { get; set; }
    }
}
