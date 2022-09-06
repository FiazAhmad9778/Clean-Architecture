using AutoMapper;
using iHakeem.Domain.Doctors.Education;
using iHakeem.SharedKernal.Domain.IUnitOfWork;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.Doctors.Education.CommadHandler.Delete
{
    public class DoctorEducationDeleteHandler : IRequestHandler<DoctorEducationDeleteRequestDTO, bool>
    {
        private readonly IDoctorEducationRepository _doctorEducationRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DoctorEducationDeleteHandler(IDoctorEducationRepository doctorEducationRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _doctorEducationRepository = doctorEducationRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(DoctorEducationDeleteRequestDTO request,
            CancellationToken cancellationToken)
        {
            var res = await _doctorEducationRepository.GetSingle(x => x.Id == request.Id);
            res.IsDeleted = true;
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
