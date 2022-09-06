using AutoMapper;
using iHakeem.Application.Patients.Contracts;
using iHakeem.Domain.Departments.IDomainRepository;
using iHakeem.Domain.EMR.CurrentMedication.IDomainRepository;
using iHakeem.Domain.Models;
using iHakeem.Domain.Patients.IApplicationService;
using iHakeem.Infrastructure.Security.Abstractions.Authorization.Roles;
using iHakeem.SharedKernal.AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.Patients.CommandHandler.Signup
{
    public class PatientSignupHandler : IRequestHandler<PatientSignupRequestDTO, PatientSignupResponseDTO>
    {
        private readonly IPatientApplicationService _patientApplicationService;
        private readonly IMapper _mapper;

        public PatientSignupHandler(IPatientApplicationService patientApplicationService,
            IMapper mapper)
        {
            _patientApplicationService = patientApplicationService;
            _mapper = mapper;
        }

        public async Task<PatientSignupResponseDTO> Handle(PatientSignupRequestDTO request,
            CancellationToken cancellationToken)
        {
            Patient patient = new Patient()
            {
                User = _mapper.Map<ApplicationUser>(request)
            };
            Patient patientResponse = await _patientApplicationService.RegisterPatient(patient, request.Password, Convert.ToInt64(UserRoles.Patient));
            return _mapper.MergeInto<PatientSignupResponseDTO>(patientResponse.User, patientResponse);
        }
    }
}
