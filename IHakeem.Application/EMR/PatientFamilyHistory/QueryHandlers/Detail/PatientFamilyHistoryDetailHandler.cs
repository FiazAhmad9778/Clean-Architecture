using AutoMapper;
using iHakeem.Application.EMR.PatientFamilyHistory.Contracts;
using iHakeem.Database.AppDbContext;
using iHakeem.Domain.EMR.PatientFamilyHistory.IDomainRepository;
using iHakeem.Infrastructure.Security.Abstractions;
using iHakeem.SharedKernal;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.EMR.PatientFamilyHistory.QueryHandlers.Detail
{
    public class PatientFamilyHistoryDetailHandler : IRequestHandler<GetPatientFamilyHistoryRequestDTO, PatientFamilyHistoryResponseDTO>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly CommonMethods _commonMethods;
        private readonly IPatientFamilyHistoryRepository _PatientFamilyHistoryRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PatientFamilyHistoryDetailHandler(IPatientFamilyHistoryRepository PatientFamilyHistoryRepository, ApplicationDbContext dbContext,
            IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _PatientFamilyHistoryRepository = PatientFamilyHistoryRepository;
            _dbContext = dbContext;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _commonMethods = new CommonMethods(_httpContextAccessor);
        }
        public async Task<PatientFamilyHistoryResponseDTO> Handle(GetPatientFamilyHistoryRequestDTO request, CancellationToken cancellationToken)
        {
            var user = await _PatientFamilyHistoryRepository.GetSingle(request.Id);
            var patientId = _commonMethods.GetClaim(ClaimConstant.ReferenceId);
            return _mapper.Map<PatientFamilyHistoryResponseDTO>(user);
        }
    }
}
