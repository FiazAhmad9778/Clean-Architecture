using AutoMapper;
using iHakeem.Application.EMR.SocialHistory.Contracts;
using iHakeem.Database.AppDbContext;
using iHakeem.Domain.EMR.SocialHistory.IDomainRepository;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using iHakeem.SharedKernal;
using iHakeem.Domain.Patients.IApplicationService;
using System.Security.Claims;

namespace iHakeem.Application.EMR.SocialHistory.QueryHandlers.Detail
{
    public class GetAllSocialHistoryDetailHandler : IRequestHandler<GetAllSocialHistoryDetailRequestDTO, List<SocialHistoryResponseDTO>>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ISocialHistoryRepository _SocialHistoryRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly CommonMethods _commonMethods;
        private readonly IPatientApplicationService _patientApplicationService;
        public GetAllSocialHistoryDetailHandler(ISocialHistoryRepository SocialHistoryRepository, ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor, IPatientApplicationService patientApplicationService,
            IMapper mapper)
        {
            _SocialHistoryRepository = SocialHistoryRepository;
            _dbContext = dbContext;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _patientApplicationService = patientApplicationService;
            _commonMethods = new CommonMethods(_httpContextAccessor);
        }
        public async Task<List<SocialHistoryResponseDTO>> Handle(GetAllSocialHistoryDetailRequestDTO request, CancellationToken cancellationToken)
        {
            var result = await _patientApplicationService.GetPatientByUserId(_commonMethods.GetClaim(ClaimTypes.NameIdentifier));
            var user = await _SocialHistoryRepository.GetAll(s => s.PatientId == result.Id && s.IsDeleted == false);
            return _mapper.Map<List<SocialHistoryResponseDTO>>(user);
        }
    }
}
