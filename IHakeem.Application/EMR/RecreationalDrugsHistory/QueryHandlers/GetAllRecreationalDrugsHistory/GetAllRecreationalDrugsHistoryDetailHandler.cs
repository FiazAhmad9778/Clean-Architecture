using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using iHakeem.Application.EMR.RecreationalDrugsHistory.Contracts;
using iHakeem.Database.AppDbContext;
using CurrentMed = iHakeem.Domain.Models.RecreationalDrugsHistory;
using iHakeem.Domain.EMR.RecreationalDrugsHistory.IDomainRepository;
using iHakeem.Infrastructure.Common.Exceptions;
using MediatR;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Http;
using iHakeem.SharedKernal;
using iHakeem.Domain.Patients.IApplicationService;
using System.Security.Claims;

namespace iHakeem.Application.EMR.RecreationalDrugsHistory.QueryHandlers.Detail
{
    public class GetAllRecreationalDrugsHistoryDetailHandler : IRequestHandler<GetAllRecreationalDrugsHistoryDetailRequestDTO, List<RecreationalDrugsHistoryResponseDTO>>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IRecreationalDrugsHistoryRepository _RecreationalDrugsHistoryRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly CommonMethods _commonMethods;
        private readonly IPatientApplicationService _patientApplicationService;
        public GetAllRecreationalDrugsHistoryDetailHandler(IRecreationalDrugsHistoryRepository RecreationalDrugsHistoryRepository, ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor, IPatientApplicationService patientApplicationService,
            IMapper mapper)
        {
            _RecreationalDrugsHistoryRepository = RecreationalDrugsHistoryRepository;
            _dbContext = dbContext;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _patientApplicationService = patientApplicationService;
            _commonMethods = new CommonMethods(_httpContextAccessor);
        }
        public async Task<List<RecreationalDrugsHistoryResponseDTO>> Handle(GetAllRecreationalDrugsHistoryDetailRequestDTO request, CancellationToken cancellationToken)
        {
            var result = await _patientApplicationService.GetPatientByUserId(_commonMethods.GetClaim(ClaimTypes.NameIdentifier));
            var user = await _RecreationalDrugsHistoryRepository.GetAll(s => s.PatientId == result.Id && s.IsDeleted == false);
            return _mapper.Map<List<RecreationalDrugsHistoryResponseDTO>>(user);
        }
    }
}
