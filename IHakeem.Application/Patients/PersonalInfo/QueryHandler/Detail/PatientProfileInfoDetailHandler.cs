using AutoMapper;
using iHakeem.Application.Patients.PersonalInfo.Contracts;
using iHakeem.Domain.Patients.IDomainRepository;
using iHakeem.Infrastructure.Security.Abstractions;
using iHakeem.SharedKernal;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.Patients.PersonalInfo.QueryHandler.Detail
{
    public class PatientProfileInfoDetailHandler : IRequestHandler<PatientProfileInfoDetailRequestDTO, PatientPersonalInfoResponseDTO>
    {
        private readonly IMapper _mapper;
        private readonly CommonMethods _commonMethods;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IPatientRepository _patientRepository;

        public PatientProfileInfoDetailHandler(IPatientRepository PatientRepository,
            IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _patientRepository = PatientRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _commonMethods = new CommonMethods(_httpContextAccessor);
        }

        public async Task<PatientPersonalInfoResponseDTO> Handle(PatientProfileInfoDetailRequestDTO query, CancellationToken cancellationToken)
        {
            var patientId = _commonMethods.GetClaim(ClaimConstant.ReferenceId);
            var existingPatient = await _patientRepository.GetSingle(x => x.Id == patientId,
                x => x.User,
                x => x.User.Gender,
                x => x.User.Title,
                x => x.BloodGroup,
                x => x.Ethnicity,
                x => x.MaritialStatus,
                x => x.PreferedLanguage);
            return _mapper.Map<PatientPersonalInfoResponseDTO>(existingPatient);
        }
    }
}
