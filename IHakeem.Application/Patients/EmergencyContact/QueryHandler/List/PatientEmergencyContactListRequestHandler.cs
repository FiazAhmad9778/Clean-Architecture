using AutoMapper;
using iHakeem.Application.Patients.EmergencyContact.Contracts;
using iHakeem.Domain.Patients.PatientSocialInfo.IDomainRepository;
using iHakeem.Infrastructure.Security.Abstractions;
using iHakeem.SharedKernal;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.Patients.EmergencyContact.QueryHandler.List
{
    public class PatientEmergencyContactRequestHandler : IRequestHandler<PatientEmergencyContactListRequestDTO, List<PatientEmergencyContactDTO>>
    {
        private readonly IPatientEmergencyContactRepository _patientEmergencyContactRepository;
        private readonly IMapper _mapper;
        private readonly CommonMethods _commonMethods;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PatientEmergencyContactRequestHandler(IPatientEmergencyContactRepository patientEmergencyContactRepository,
            IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _patientEmergencyContactRepository = patientEmergencyContactRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _commonMethods = new CommonMethods(_httpContextAccessor);
        }

        public async Task<List<PatientEmergencyContactDTO>> Handle(PatientEmergencyContactListRequestDTO query, CancellationToken cancellationToken)
        {
            return _mapper.Map<List<PatientEmergencyContactDTO>>(await _patientEmergencyContactRepository.GetAll(x => x.PatientId == query.DoctorId && x.IsDeleted == false));
        }
    }
}
