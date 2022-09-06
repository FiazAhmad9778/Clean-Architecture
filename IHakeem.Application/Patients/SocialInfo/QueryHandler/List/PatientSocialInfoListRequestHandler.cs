using AutoMapper;
using iHakeem.Application.Doctors.SocialInfo.Contracts;
using iHakeem.Application.Patients.SocialInfo.Contracts;
using iHakeem.Domain.Patients.SocialInfo.IDomainRepository;
using iHakeem.Infrastructure.Security.Abstractions;
using iHakeem.SharedKernal;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.Patients.PatientSocialInfo.QueryHandler.List
{
    public class PatientSocialInfoListRequestHandler : IRequestHandler<PatientSocialInfoListRequestDTO, List<PatientSocialInfoDTO>>
    {
        private readonly IPatientSocialInformationRepository _patientSocialInformationRepository;
        private readonly IMapper _mapper;
        private readonly CommonMethods _commonMethods;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PatientSocialInfoListRequestHandler(IPatientSocialInformationRepository patientSocialInformationRepository,
            IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _patientSocialInformationRepository = patientSocialInformationRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _commonMethods = new CommonMethods(_httpContextAccessor);
        }

        public async Task<List<PatientSocialInfoDTO>> Handle(PatientSocialInfoListRequestDTO query, CancellationToken cancellationToken)
        {
            return _mapper.Map<List<PatientSocialInfoDTO>>(await _patientSocialInformationRepository.AllIncluding(x => x.PatientId == query.DoctorId, x => x.SocialInformation));
        }
    }
}
