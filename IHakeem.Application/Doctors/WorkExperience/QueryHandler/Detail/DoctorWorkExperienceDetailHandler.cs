using AutoMapper;
using iHakeem.Application.Doctors.WorkExperience.Contracts;
using iHakeem.Database.AppDbContext;
using iHakeem.Domain.Doctors.WorkExperience.IDomainRepository;
using iHakeem.Infrastructure.Security.Abstractions;
using iHakeem.SharedKernal;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.Doctors.WorkExperience.QueryHandler.Detail
{
    public class DoctorWorkExperienceDetailHandler : IRequestHandler<DoctorWorkExperienceDetailRequestDTO, DoctorWorkExperienceDTO>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly CommonMethods _commonMethods;
        private readonly IDoctorWorkExperienceRepository _doctorWorkExperienceRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DoctorWorkExperienceDetailHandler(IDoctorWorkExperienceRepository doctorWorkExperienceRepository, ApplicationDbContext dbContext,
            IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _doctorWorkExperienceRepository = doctorWorkExperienceRepository;
            _dbContext = dbContext;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _commonMethods = new CommonMethods(_httpContextAccessor);
        }
        public async Task<DoctorWorkExperienceDTO> Handle(DoctorWorkExperienceDetailRequestDTO request, CancellationToken cancellationToken)
        {
            var user = await _doctorWorkExperienceRepository.GetSingle(x => x.Id == request.Id && x.IsDeleted == false);
            return _mapper.Map<DoctorWorkExperienceDTO>(user);
        }
    }
}
