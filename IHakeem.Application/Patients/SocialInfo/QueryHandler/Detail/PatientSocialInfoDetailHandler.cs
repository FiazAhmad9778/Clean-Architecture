using AutoMapper;
using iHakeem.Application.Doctors.SocialInfo.Contracts;
using iHakeem.Application.Patients.EmergencyContact.Contracts;
using iHakeem.Application.Patients.SocialInfo.Contracts;
using iHakeem.Database.AppDbContext;
using iHakeem.Domain.Patients.SocialInfo.IDomainRepository;
using iHakeem.SharedKernal;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.Patients.SocialInfo.QueryHandler.Detail
{
    public class PatientSocialInfoDetailHandler : IRequestHandler<PatientSocialInfoDetailRequestDTO, PatientSocialInfoDTO>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly CommonMethods _commonMethods;
        private readonly IPatientSocialInformationRepository _patientEmergencyContactRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PatientSocialInfoDetailHandler(IPatientSocialInformationRepository patientSocialInfoRepository, ApplicationDbContext dbContext,
            IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _patientEmergencyContactRepository = patientSocialInfoRepository;
            _dbContext = dbContext;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _commonMethods = new CommonMethods(_httpContextAccessor);
        }
        public async Task<PatientSocialInfoDTO> Handle(PatientSocialInfoDetailRequestDTO request, CancellationToken cancellationToken)
        {
            return _mapper.Map<PatientSocialInfoDTO>(await _patientEmergencyContactRepository.GetSingle(x => x.SocialInformationId == request.Id && x.IsDeleted == false, x => x.SocialInformation));
        }
    }
}
