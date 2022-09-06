using AutoMapper;
using iHakeem.Application.EMR.PatientHobbiesHistory.Contracts;
using iHakeem.Database.AppDbContext;
using iHakeem.Domain.EMR.PatientHobbiesHistory.IDomainRepository;
using iHakeem.Infrastructure.Security.Abstractions;
using iHakeem.SharedKernal;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.EMR.PatientHobbiesHistory.QueryHandlers.Detail
{
    public class PatientHobbiesHistoryDetailHandler : IRequestHandler<GetPatientHobbiesHistoryRequestDTO, PatientHobbiesHistoryResponseDTO>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly CommonMethods _commonMethods;
        private readonly IPatientHobbiesHistoryRepository _PatientHobbiesHistoryRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PatientHobbiesHistoryDetailHandler(IPatientHobbiesHistoryRepository PatientHobbiesHistoryRepository, ApplicationDbContext dbContext,
            IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _PatientHobbiesHistoryRepository = PatientHobbiesHistoryRepository;
            _dbContext = dbContext;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _commonMethods = new CommonMethods(_httpContextAccessor);
        }
        public async Task<PatientHobbiesHistoryResponseDTO> Handle(GetPatientHobbiesHistoryRequestDTO request, CancellationToken cancellationToken)
        {
            var user = await _PatientHobbiesHistoryRepository.GetSingle(request.Id);
            var patientId = _commonMethods.GetClaim(ClaimConstant.ReferenceId);
            return _mapper.Map<PatientHobbiesHistoryResponseDTO>(user);
        }
    }
}
