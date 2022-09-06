using AutoMapper;
using iHakeem.Application.Doctors.SkillsAndtraining.Contracts;
using iHakeem.Application.Doctors.WorkExperience.Contracts;
using iHakeem.Application.Doctors.WorkExperience.QueryHandler.List;
using iHakeem.Domain.Doctors.TrainingAndSkills.IDomainRepository;
using iHakeem.Domain.Doctors.WorkExperience.IDomainRepository;
using iHakeem.Infrastructure.Security.Abstractions;
using iHakeem.SharedKernal;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.Doctors.SkillsAndtraining.QueryHandler.Detail
{
    public class DoctorWorkExperienceDetailRequestHandler : IRequestHandler<DoctorWorkExperienceListRequestDTO, List<DoctorWorkExperienceDTO>>
    {
        private readonly IDoctorWorkExperienceRepository _doctorWorkExperienceRepository;
        private readonly IMapper _mapper;
        private readonly CommonMethods _commonMethods;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DoctorWorkExperienceDetailRequestHandler(IDoctorWorkExperienceRepository doctorWorkExperienceRepository,
            IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _doctorWorkExperienceRepository = doctorWorkExperienceRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _commonMethods = new CommonMethods(_httpContextAccessor);
        }

        public async Task<List<DoctorWorkExperienceDTO>> Handle(DoctorWorkExperienceListRequestDTO query, CancellationToken cancellationToken)
        {
            return _mapper.Map<List<DoctorWorkExperienceDTO>>(await _doctorWorkExperienceRepository.GetAll(x => x.DoctorId == query.DoctorId && x.IsDeleted == false));
        }
    }
}
