using AutoMapper;
using iHakeem.Domain.Doctors.WorkExperience.IDomainRepository;
using iHakeem.SharedKernal.Domain.IUnitOfWork;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.Doctors.WorkExperience.CommadHandler.Delete
{
    public class DoctorWorkExperienceDeleteHandler : IRequestHandler<DoctorWorkExperienceDeleteRequestDTO, bool>
    {
        private readonly IDoctorWorkExperienceRepository _doctorWorkExperienceRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DoctorWorkExperienceDeleteHandler(IDoctorWorkExperienceRepository doctorWorkExperienceRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _doctorWorkExperienceRepository = doctorWorkExperienceRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(DoctorWorkExperienceDeleteRequestDTO request,
            CancellationToken cancellationToken)
        {
            var res = await _doctorWorkExperienceRepository.GetSingle(x => x.Id == request.Id);
            res.IsDeleted = true;
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
