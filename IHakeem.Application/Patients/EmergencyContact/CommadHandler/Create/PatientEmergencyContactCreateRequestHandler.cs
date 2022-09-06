using AutoMapper;
using iHakeem.Application.Patients.EmergencyContact.Contracts;
using iHakeem.Application.Patients.PersonalInfo.Contracts;
using iHakeem.Domain.Models;
using iHakeem.Domain.Patients.PatientSocialInfo.IDomainRepository;
using iHakeem.SharedKernal.Domain.IUnitOfWork;
using MAP.Common.Extensions;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.Patients.EmergencyContact.CommadHandler.Create
{
    public class PatientEmergencyContactRequestHandler : IRequestHandler<PatientEmergencyContactCreateRequestDTO, PatientEmergencyContactDTO>
    {
        private readonly IPatientEmergencyContactRepository _patientEmergencyContactRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PatientEmergencyContactRequestHandler(IPatientEmergencyContactRepository patientEmergencyContactRepository,
            IMapper mapper, IUnitOfWork unitOfWork)
        {
            _patientEmergencyContactRepository = patientEmergencyContactRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<PatientEmergencyContactDTO> Handle(PatientEmergencyContactCreateRequestDTO request, CancellationToken cancellationToken)
        {

            var patientEmergencyContactDTO = _mapper.Map<PatientEmergencyContact>(request);
            if (patientEmergencyContactDTO != null)
            {
                _patientEmergencyContactRepository.AddOrUpdate(patientEmergencyContactDTO);
            }
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<PatientEmergencyContactDTO>(patientEmergencyContactDTO);
        }
    }
}