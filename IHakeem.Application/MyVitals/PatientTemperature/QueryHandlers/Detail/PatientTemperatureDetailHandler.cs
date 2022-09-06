using AutoMapper;
using iHakeem.Application.MyVitals.PatientTemperature.Contracts;
using iHakeem.Database.AppDbContext;
using iHakeem.Domain.MyVitals.PatientTemperature.IDomainRepository;
using iHakeem.Infrastructure.Security.Abstractions;
using iHakeem.SharedKernal;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.MyVitals.PatientTemperature.QueryHandlers.Detail
{
    public class PatientTemperatureDetailHandler : IRequestHandler<GetPatientTemperatureRequestDTO, PatientTemperatureResponseDTO>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly CommonMethods _commonMethods;
        private readonly IPatientTemperatureRepository _PatientTemperatureRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PatientTemperatureDetailHandler(IPatientTemperatureRepository PatientTemperatureRepository, ApplicationDbContext dbContext,
            IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _PatientTemperatureRepository = PatientTemperatureRepository;
            _dbContext = dbContext;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _commonMethods = new CommonMethods(_httpContextAccessor);
        }
        public async Task<PatientTemperatureResponseDTO> Handle(GetPatientTemperatureRequestDTO request, CancellationToken cancellationToken)
        {
            var user = await _PatientTemperatureRepository.GetSingle(request.Id);
            var patientId = _commonMethods.GetClaim(ClaimConstant.ReferenceId);
            return _mapper.Map<PatientTemperatureResponseDTO>(user);
        }
    }
}
