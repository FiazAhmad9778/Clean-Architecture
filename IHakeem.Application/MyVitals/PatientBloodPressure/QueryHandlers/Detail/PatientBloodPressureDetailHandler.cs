using AutoMapper;
using iHakeem.Application.MyVitals.PatientBloodPressure.Contracts;
using iHakeem.Database.AppDbContext;
using iHakeem.Domain.MyVitals.PatientBloodPressure.IDomainRepository;
using iHakeem.Infrastructure.Security.Abstractions;
using iHakeem.SharedKernal;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.MyVitals.PatientBloodPressure.QueryHandlers.Detail
{
    public class PatientBloodPressureDetailHandler : IRequestHandler<GetPatientBloodPressureRequestDTO, PatientBloodPressureResponseDTO>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly CommonMethods _commonMethods;
        private readonly IPatientBloodPressureRepository _PatientBloodPressureRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PatientBloodPressureDetailHandler(IPatientBloodPressureRepository PatientBloodPressureRepository, ApplicationDbContext dbContext,
            IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _PatientBloodPressureRepository = PatientBloodPressureRepository;
            _dbContext = dbContext;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _commonMethods = new CommonMethods(_httpContextAccessor);
        }
        public async Task<PatientBloodPressureResponseDTO> Handle(GetPatientBloodPressureRequestDTO request, CancellationToken cancellationToken)
        {
            var user = await _PatientBloodPressureRepository.GetSingle(request.Id);
            var patientId = _commonMethods.GetClaim(ClaimConstant.ReferenceId);
            return _mapper.Map<PatientBloodPressureResponseDTO>(user);
        }
    }
}
