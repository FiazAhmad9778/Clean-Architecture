using AutoMapper;
using iHakeem.Domain.Doctors.TrainingAndSkills.IDomainRepository;
using iHakeem.SharedKernal.Domain.IUnitOfWork;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.Doctors.SkillsAndtraining.CommadHandler.Delete
{
    public class DoctorSkillsAndTrainingDeleteHandler : IRequestHandler<DoctorSkillsAndTrainingDeleteRequestDTO, bool>
    {
        private readonly IDoctorSkillsAndTrainingRepository _doctorSkillsAndTrainingRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DoctorSkillsAndTrainingDeleteHandler(IDoctorSkillsAndTrainingRepository doctorSkillsAndTrainingRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _doctorSkillsAndTrainingRepository = doctorSkillsAndTrainingRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(DoctorSkillsAndTrainingDeleteRequestDTO request,
            CancellationToken cancellationToken)
        {
            var res = await _doctorSkillsAndTrainingRepository.GetSingle(x => x.Id == request.Id);
            res.IsDeleted = true;
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
