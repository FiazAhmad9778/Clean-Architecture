using AutoMapper;
using iHakeem.Domain.Doctors.AwardsAndRecognitions.IDomainRepository;
using iHakeem.SharedKernal.Domain.IUnitOfWork;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.Doctors.AwardsAndRecognitions.CommadHandler.Delete
{
    public class DoctorAwardsAndRecognitionDeleteHandler : IRequestHandler<DoctorAwardsAndRecognitionDeleteRequestDTO, bool>
    {
        private readonly IDoctorAwardsAndRecognitionRepository _doctorAwardsAndRecognitionRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DoctorAwardsAndRecognitionDeleteHandler(IDoctorAwardsAndRecognitionRepository doctorAwardsAndRecognitionRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _doctorAwardsAndRecognitionRepository = doctorAwardsAndRecognitionRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(DoctorAwardsAndRecognitionDeleteRequestDTO request,
            CancellationToken cancellationToken)
        {
            var res = await _doctorAwardsAndRecognitionRepository.GetSingle(x => x.Id == request.Id);
            res.IsDeleted = true;
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
