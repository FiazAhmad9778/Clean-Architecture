using AutoMapper;
using iHakeem.Application.Patients.PatientGaurdians.CommandHandlers.CreateOrUpdate;
using iHakeem.Application.Patients.PersonalInfo.Contracts;
using iHakeem.Domain.Patients.IDomainRepository;
using iHakeem.Infrastructure.Common.Exceptions;
using iHakeem.SharedKernal;
using iHakeem.SharedKernal.Domain.IUnitOfWork;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.Patients.PersonalInfo.CommadHandler.Update
{
    public class PatientPersonalInfoUpdateRequestHandler : IRequestHandler<PatientPersonalInfoUpdateRequestDTO, PatientPersonalInfoResponseDTO>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPatientRepository _patientRepository;

        public PatientPersonalInfoUpdateRequestHandler(IPatientRepository PatientRepository,
            IMapper mapper, IUnitOfWork unitOfWork)
        {
            _patientRepository = PatientRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<PatientPersonalInfoResponseDTO> Handle(PatientPersonalInfoUpdateRequestDTO request, CancellationToken cancellationToken)
        {
            var existingPatient = await _patientRepository.GetSingle(x => x.Id == request.Id,
                x => x.User,
                x => x.User.Gender,
                x => x.User.Title,
                x => x.BloodGroup,
                x => x.Ethnicity,
                x => x.MaritialStatus,
                x => x.PreferedLanguage);
            if (existingPatient == null) throw new CodedException(ErrorCode.InvalidPatientId);

            _mapper.Map(request, existingPatient);
            existingPatient.User.FirstName = request.FirstName;
            existingPatient.User.LastName = request.LastName;
            existingPatient.User.TitleId = request.TitleId;
            existingPatient.User.GenderId = request.GenderId;
            var respoonse = _patientRepository.Update(existingPatient);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<PatientPersonalInfoResponseDTO>(respoonse);

        }
    }
}