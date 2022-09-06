using AutoMapper;
using iHakeem.Application.EMR.CurrentMedication.Contracts;
using iHakeem.Domain.EMR.CurrentMedication.IDomainRepository;
using iHakeem.Domain.Patients.IApplicationService;
using iHakeem.Domain.Patients.IDomainRepository;
using iHakeem.Infrastructure.Common;
using iHakeem.Infrastructure.Security.Abstractions;
using iHakeem.SharedKernal;
using iHakeem.SharedKernal.Domain.IUnitOfWork;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using CurrentMed = iHakeem.Domain.Models.CurrentMedication;

namespace iHakeem.Application.EMR.CurrentMedication.CommandHandlers.Create
{
    public class PatientSignupHandler : IRequestHandler<CreateCurrentMedicationRequestDTO, CurrentMedicationResponseDTO>
    {
        private readonly ICurrentMedicationRepository _currentMedicationRepository;
        private readonly IPatientApplicationService _patientApplicationService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly CommonMethods _commonMethods;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IUnitOfWork _unitOfWork;
        public PatientSignupHandler(ICurrentMedicationRepository currentMedicationRepository, IHttpContextAccessor httpContextAccessor, IPatientApplicationService patientApplicationService,
        IDateTimeProvider dateTimeProvider,
        IUnitOfWork unitOfWork,
        IMapper mapper)
        {
            _currentMedicationRepository = currentMedicationRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _patientApplicationService = patientApplicationService;
            _commonMethods = new CommonMethods(_httpContextAccessor);
            _dateTimeProvider = dateTimeProvider;
            _unitOfWork = unitOfWork;

        }
        public async Task<CurrentMedicationResponseDTO> Handle(CreateCurrentMedicationRequestDTO request,
            CancellationToken cancellationToken)
        {
            CurrentMed user = _mapper.Map<CurrentMed>(request);
            user.PatientId = _commonMethods.GetClaim(ClaimConstant.ReferenceId);
            user.CreatedBy = Convert.ToInt64(_commonMethods.GetClaim(ClaimTypes.NameIdentifier));
            user.CreatedDate = _dateTimeProvider.PlatformSpecificNow;
            var response = await _currentMedicationRepository.Add(user);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<CurrentMedicationResponseDTO>(response);
        }
    }
}
