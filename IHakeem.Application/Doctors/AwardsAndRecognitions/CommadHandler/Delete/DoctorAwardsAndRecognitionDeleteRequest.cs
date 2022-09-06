using MediatR;

namespace iHakeem.Application.Doctors.AwardsAndRecognitions.CommadHandler.Delete
{
    public class DoctorAwardsAndRecognitionDeleteRequestDTO : IRequest<bool>
    {
        public long Id { get; set; }
    }
}
