using AutoMapper;
using iHakeem.Application.Doctors.SkillsAndtraining.Contracts;
using iHakeem.Database.AppDbContext;
using iHakeem.Domain.Doctors.TrainingAndSkills.IDomainRepository;
using iHakeem.Infrastructure.Security.Abstractions;
using iHakeem.SharedKernal;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.Doctors.SkillsAndtraining.QueryHandler.Detail
{
    public class DoctorSkillsAndtrainingDetailHandler : IRequestHandler<DoctorSkillsAndtrainingDetailRequestDTO, DoctorSkillsAndTrainingDTO>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly CommonMethods _commonMethods;
        private readonly IDoctorSkillsAndTrainingRepository _doctorSkillsAndtrainingRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DoctorSkillsAndtrainingDetailHandler(IDoctorSkillsAndTrainingRepository doctorSkillsAndtrainingRepository, ApplicationDbContext dbContext,
            IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _doctorSkillsAndtrainingRepository = doctorSkillsAndtrainingRepository;
            _dbContext = dbContext;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _commonMethods = new CommonMethods(_httpContextAccessor);
        }
        public async Task<DoctorSkillsAndTrainingDTO> Handle(DoctorSkillsAndtrainingDetailRequestDTO request, CancellationToken cancellationToken)
        {
            return _mapper.Map<DoctorSkillsAndTrainingDTO>(await _doctorSkillsAndtrainingRepository.GetSingle(x => x.Id == request.Id && x.IsDeleted == false));
        }
    }
}
