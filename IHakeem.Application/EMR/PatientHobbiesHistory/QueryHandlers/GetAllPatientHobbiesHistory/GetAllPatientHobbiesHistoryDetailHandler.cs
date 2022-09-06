using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using iHakeem.Application.EMR.PatientHobbiesHistory.Contracts;
using iHakeem.Database.AppDbContext;
using CurrentMed = iHakeem.Domain.Models.PatientHobbiesHistory;
using iHakeem.Domain.EMR.PatientHobbiesHistory.IDomainRepository;
using iHakeem.Infrastructure.Common.Exceptions;
using MediatR;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Http;
using iHakeem.SharedKernal;
using iHakeem.Domain.Patients.IApplicationService;
using System.Security.Claims;

namespace iHakeem.Application.EMR.PatientHobbiesHistory.QueryHandlers.Detail
{
    public class GetAllPatientHobbiesHistoryDetailHandler : IRequestHandler<GetAllPatientHobbiesHistoryDetailRequestDTO, List<PatientHobbiesHistoryResponseDTO>>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IPatientHobbiesHistoryRepository _PatientHobbiesHistoryRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly CommonMethods _commonMethods;
        private readonly IPatientApplicationService _patientApplicationService;
        public GetAllPatientHobbiesHistoryDetailHandler(IPatientHobbiesHistoryRepository PatientHobbiesHistoryRepository, IHttpContextAccessor httpContextAccessor, IPatientApplicationService patientApplicationService, ApplicationDbContext dbContext,
            IMapper mapper)
        {
            _PatientHobbiesHistoryRepository = PatientHobbiesHistoryRepository;
            _dbContext = dbContext;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _patientApplicationService = patientApplicationService;
            _commonMethods = new CommonMethods(_httpContextAccessor);
        }
        public async Task<List<PatientHobbiesHistoryResponseDTO>> Handle(GetAllPatientHobbiesHistoryDetailRequestDTO request, CancellationToken cancellationToken)
        {
            var result = await _patientApplicationService.GetPatientByUserId(_commonMethods.GetClaim(ClaimTypes.NameIdentifier));
            var user = await _PatientHobbiesHistoryRepository.GetAll(s => s.PatientId == result.Id && s.IsDeleted == false);
            return _mapper.Map<List<PatientHobbiesHistoryResponseDTO>>(user);
        }
    }
}
