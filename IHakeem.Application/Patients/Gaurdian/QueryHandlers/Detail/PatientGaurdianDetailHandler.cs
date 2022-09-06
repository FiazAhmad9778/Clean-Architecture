using AutoMapper;
using iHakeem.Application.Patients.PatientGaurdians.Contracts;
using iHakeem.Database.AppDbContext;
using iHakeem.Domain.Patients.PatientGaurdians.IDomainRepository;
using iHakeem.Infrastructure.Security.Abstractions;
using iHakeem.SharedKernal;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.Patients.PatientGaurdians.QueryHandlers.Detail
{
    public class PatientGaurdianDetailHandler : IRequestHandler<GetPatientGaurdianRequestDTO, PatientGaurdianResponseDTO>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly CommonMethods _commonMethods;
        private readonly IPatientGaurdianRepository _patientGaurdianRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PatientGaurdianDetailHandler(IPatientGaurdianRepository patientGaurdianRepository, ApplicationDbContext dbContext,
            IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _patientGaurdianRepository = patientGaurdianRepository;
            _dbContext = dbContext;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _commonMethods = new CommonMethods(_httpContextAccessor);
        }
        public async Task<PatientGaurdianResponseDTO> Handle(GetPatientGaurdianRequestDTO request, CancellationToken cancellationToken)
        {
            return _mapper.Map<PatientGaurdianResponseDTO>(await _patientGaurdianRepository.GetSingle(request.Id));
        }
    }
}
