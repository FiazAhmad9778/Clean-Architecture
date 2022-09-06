using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using iHakeem.Application.EMR.PregnanciesHistory.Contracts;
using iHakeem.Database.AppDbContext;
using CurrentMed = iHakeem.Domain.Models.PregnanciesHistory;
using iHakeem.Domain.EMR.PregnanciesHistory.IDomainRepository;
using iHakeem.Infrastructure.Common.Exceptions;
using MediatR;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Http;
using iHakeem.SharedKernal;
using iHakeem.Domain.Patients.IApplicationService;
using System.Security.Claims;

namespace iHakeem.Application.EMR.PregnanciesHistory.QueryHandlers.Detail
{
    public class GetAllPregnanciesHistoryDetailHandler : IRequestHandler<GetAllPregnanciesHistoryDetailRequestDTO, List<PregnanciesHistoryResponseDTO>>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IPregnanciesHistoryRepository _PregnanciesHistoryRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly CommonMethods _commonMethods;
        private readonly IPatientApplicationService _patientApplicationService;
        public GetAllPregnanciesHistoryDetailHandler(IPregnanciesHistoryRepository PregnanciesHistoryRepository, IHttpContextAccessor httpContextAccessor, IPatientApplicationService patientApplicationService, ApplicationDbContext dbContext,
            IMapper mapper)
        {
            _PregnanciesHistoryRepository = PregnanciesHistoryRepository;
            _dbContext = dbContext;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _patientApplicationService = patientApplicationService;
            _commonMethods = new CommonMethods(_httpContextAccessor);
        }
        public async Task<List<PregnanciesHistoryResponseDTO>> Handle(GetAllPregnanciesHistoryDetailRequestDTO request, CancellationToken cancellationToken)
        {
            var result = await _patientApplicationService.GetPatientByUserId(_commonMethods.GetClaim(ClaimTypes.NameIdentifier));
            var user = await _PregnanciesHistoryRepository.GetAll(s => s.PatientId == result.Id && s.IsDeleted == false);
            return _mapper.Map<List<PregnanciesHistoryResponseDTO>>(user);
        }
    }
}
