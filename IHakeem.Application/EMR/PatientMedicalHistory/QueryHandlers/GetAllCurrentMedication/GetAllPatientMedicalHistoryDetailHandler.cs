using AutoMapper;
using iHakeem.Application.EMR.PatientMedicalHistory.Contracts;
using iHakeem.Database.AppDbContext;
using iHakeem.Domain.EMR.PatientMedicalHistory.IDomainRepository;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using iHakeem.SharedKernal;
using iHakeem.Domain.Patients.IApplicationService;
using System.Security.Claims;

namespace iHakeem.Application.EMR.PatientMedicalHistory.QueryHandlers.Detail
{
    public class GetAllPatientMedicalHistoryDetailHandler : IRequestHandler<GetAllPatientMedicalHistoryDetailRequestDTO, List<PatientMedicalHistoryResponseDTO>>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IPatientMedicalHistoryRepository _PatientMedicalHistoryRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly CommonMethods _commonMethods;
        private readonly IPatientApplicationService _patientApplicationService;
        public GetAllPatientMedicalHistoryDetailHandler(IPatientMedicalHistoryRepository PatientMedicalHistoryRepository, ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor, IPatientApplicationService patientApplicationService,
            IMapper mapper)
        {
            _PatientMedicalHistoryRepository = PatientMedicalHistoryRepository;
            _dbContext = dbContext;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _patientApplicationService = patientApplicationService;
            _commonMethods = new CommonMethods(_httpContextAccessor);
        }
        public async Task<List<PatientMedicalHistoryResponseDTO>> Handle(GetAllPatientMedicalHistoryDetailRequestDTO request, CancellationToken cancellationToken)
        {
            var result = await _patientApplicationService.GetPatientByUserId(_commonMethods.GetClaim(ClaimTypes.NameIdentifier));
            var user = await _PatientMedicalHistoryRepository.GetAll(s => s.PatientId == result.Id && s.IsDeleted == false);
            return _mapper.Map<List<PatientMedicalHistoryResponseDTO>>(user);
        }
    }
}
