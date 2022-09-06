using AutoMapper;
using iHakeem.Application.Doctors.SkillsAndtraining.Contracts;
using iHakeem.Application.Doctors.SkillsAndtraining.QueryHandler.List;
using iHakeem.Domain.Doctors.TrainingAndSkills.IDomainRepository;
using iHakeem.Infrastructure.Security.Abstractions;
using iHakeem.SharedKernal;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.Doctors.SkillsAndtraining.QueryHandler.Detail
{
    public class DoctorSkillsAndTrainingRequestHandler : IRequestHandler<DoctorSkillsAndTrainingListRequestDTO, List<DoctorSkillsAndTrainingDTO>>
    {
        private readonly IDoctorSkillsAndTrainingRepository _doctorSkillsAndTrainingRepository;
        private readonly IMapper _mapper;
        private readonly CommonMethods _commonMethods;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DoctorSkillsAndTrainingRequestHandler(IDoctorSkillsAndTrainingRepository doctorSkillsAndTrainingRepository,
            IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _doctorSkillsAndTrainingRepository = doctorSkillsAndTrainingRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _commonMethods = new CommonMethods(_httpContextAccessor);
        }

        public async Task<List<DoctorSkillsAndTrainingDTO>> Handle(DoctorSkillsAndTrainingListRequestDTO query, CancellationToken cancellationToken)
        {
            return _mapper.Map<List<DoctorSkillsAndTrainingDTO>>(await _doctorSkillsAndTrainingRepository.GetAll(x => x.DoctorId == query.DoctorId && x.IsDeleted == false));
        }
    }
}
