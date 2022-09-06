using AutoMapper;
using iHakeem.Application.MyVitals.PatientWeight.Contracts;
using iHakeem.Database.AppDbContext;
using iHakeem.Domain.MyVitals.PatientWeight.IDomainRepository;
using iHakeem.Infrastructure.Security.Abstractions;
using iHakeem.SharedKernal;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.MyVitals.PatientWeight.QueryHandlers.Detail
{
    public class PatientWeightDetailHandler : IRequestHandler<GetPatientWeightRequestDTO, PatientWeightResponseDTO>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly CommonMethods _commonMethods;
        private readonly IPatientWeightRepository _PatientWeightRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PatientWeightDetailHandler(IPatientWeightRepository PatientWeightRepository, ApplicationDbContext dbContext,
            IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _PatientWeightRepository = PatientWeightRepository;
            _dbContext = dbContext;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _commonMethods = new CommonMethods(_httpContextAccessor);
        }
        public async Task<PatientWeightResponseDTO> Handle(GetPatientWeightRequestDTO request, CancellationToken cancellationToken)
        {
            var user = await _PatientWeightRepository.GetSingle(request.Id);
            var patientId = _commonMethods.GetClaim(ClaimConstant.ReferenceId);
            return _mapper.Map<PatientWeightResponseDTO>(user);
        }
    }
}
