using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using iHakeem.Application.EMR.ExerciseHistory.Contracts;
using iHakeem.Database.AppDbContext;
using CurrentMed = iHakeem.Domain.Models.ExerciseHistory;
using iHakeem.Domain.EMR.ExerciseHistory.IDomainRepository;
using iHakeem.Infrastructure.Common.Exceptions;
using MediatR;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Http;
using iHakeem.SharedKernal;
using iHakeem.Domain.Patients.IApplicationService;
using System.Security.Claims;

namespace iHakeem.Application.EMR.ExerciseHistory.QueryHandlers.Detail
{
    public class GetAllExerciseHistoryDetailHandler : IRequestHandler<GetAllExerciseHistoryDetailRequestDTO, List<ExerciseHistoryResponseDTO>>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IExerciseHistoryRepository _ExerciseHistoryRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly CommonMethods _commonMethods;
        private readonly IPatientApplicationService _patientApplicationService;

        public GetAllExerciseHistoryDetailHandler(IExerciseHistoryRepository ExerciseHistoryRepository, ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor, IPatientApplicationService patientApplicationService,
            IMapper mapper)
        {
            _ExerciseHistoryRepository = ExerciseHistoryRepository;
            _dbContext = dbContext;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _patientApplicationService = patientApplicationService;
            _commonMethods = new CommonMethods(_httpContextAccessor);
        }
        public async Task<List<ExerciseHistoryResponseDTO>> Handle(GetAllExerciseHistoryDetailRequestDTO request, CancellationToken cancellationToken)
        {
            var result = await _patientApplicationService.GetPatientByUserId(_commonMethods.GetClaim(ClaimTypes.NameIdentifier));
            var user = await _ExerciseHistoryRepository.GetAll(s => s.PatientId == result.Id && s.IsDeleted == false);
            return _mapper.Map<List<ExerciseHistoryResponseDTO>>(user);
        }
    }
}
