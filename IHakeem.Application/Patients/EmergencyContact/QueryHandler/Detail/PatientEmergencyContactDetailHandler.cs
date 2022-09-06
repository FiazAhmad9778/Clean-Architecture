using AutoMapper;
using iHakeem.Application.Patients.EmergencyContact.Contracts;
using iHakeem.Database.AppDbContext;
using iHakeem.Domain.Patients.PatientSocialInfo.IDomainRepository;
using iHakeem.SharedKernal;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.Patients.PatientEmergencyContacts.QueryHandlers.Detail
{
    public class PatientEmergencyContactDetailHandler : IRequestHandler<PatientEmergencyContactDetailRequestDTO, PatientEmergencyContactDTO>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly CommonMethods _commonMethods;
        private readonly IPatientEmergencyContactRepository _patientEmergencyContactRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PatientEmergencyContactDetailHandler(IPatientEmergencyContactRepository patientEmergencyContactRepository, ApplicationDbContext dbContext,
            IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _patientEmergencyContactRepository = patientEmergencyContactRepository;
            _dbContext = dbContext;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _commonMethods = new CommonMethods(_httpContextAccessor);
        }
        public async Task<PatientEmergencyContactDTO> Handle(PatientEmergencyContactDetailRequestDTO request, CancellationToken cancellationToken)
        {
            return _mapper.Map<PatientEmergencyContactDTO>(await _patientEmergencyContactRepository.GetSingle(x => x.Id == request.Id && x.IsDeleted == false));
        }
    }
}
