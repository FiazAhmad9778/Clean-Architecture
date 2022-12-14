using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using iHakeem.Application.MyVitals.PulseOximeter.Contracts;
using iHakeem.Database.AppDbContext;
using CurrentMed = iHakeem.Domain.Models.PulseOximeter;
using iHakeem.Domain.MyVitals.PulseOximeter.IDomainRepository;
using iHakeem.Infrastructure.Common.Exceptions;
using MediatR;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Http;
using iHakeem.SharedKernal;
using iHakeem.Domain.Patients.IApplicationService;
using System.Security.Claims;

namespace iHakeem.Application.MyVitals.PulseOximeter.QueryHandlers.Detail
{
    public class GetAllPulseOximeterDetailHandler : IRequestHandler<GetAllPulseOximeterDetailRequestDTO, List<PulseOximeterResponseDTO>>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IPulseOximeterRepository _PulseOximeterRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly CommonMethods _commonMethods;
        private readonly IPatientApplicationService _patientApplicationService;
        public GetAllPulseOximeterDetailHandler(IPulseOximeterRepository PulseOximeterRepository, IHttpContextAccessor httpContextAccessor, IPatientApplicationService patientApplicationService, ApplicationDbContext dbContext,
            IMapper mapper)
        {
            _PulseOximeterRepository = PulseOximeterRepository;
            _dbContext = dbContext;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _patientApplicationService = patientApplicationService;
            _commonMethods = new CommonMethods(_httpContextAccessor);
        }
        public async Task<List<PulseOximeterResponseDTO>> Handle(GetAllPulseOximeterDetailRequestDTO request, CancellationToken cancellationToken)
        {
            var result = await _patientApplicationService.GetPatientByUserId(_commonMethods.GetClaim(ClaimTypes.NameIdentifier));
            var user = await _PulseOximeterRepository.GetAll(s => s.PatientId == result.Id && s.IsDeleted == false);
            return _mapper.Map<List<PulseOximeterResponseDTO>>(user);
        }
    }
}
