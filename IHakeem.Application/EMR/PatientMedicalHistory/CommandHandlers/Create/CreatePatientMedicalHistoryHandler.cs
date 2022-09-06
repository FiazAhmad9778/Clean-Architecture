using AutoMapper;
using iHakeem.Application.EMR.PatientMedicalHistory.Contracts;
using iHakeem.Domain.EMR.PatientMedicalHistory.IDomainRepository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using PatientMed = iHakeem.Domain.Models.PatientMedicalHistory;
using Microsoft.AspNetCore.Http;
using iHakeem.SharedKernal;
using iHakeem.Domain.Patients.IApplicationService;
using System.Security.Claims;
using iHakeem.Infrastructure.Common;
using System;
using iHakeem.Infrastructure.Security.Abstractions;
using iHakeem.SharedKernal.Domain.IUnitOfWork;

namespace iHakeem.Application.EMR.PatientMedicalHistory.CommandHandlers.Create
{
    public class CreatePatientMedicalHistoryHandler : IRequestHandler<CreatePatientMedicalHistoryRequestDTO, PatientMedicalHistoryResponseDTO>
    {
        private readonly IPatientMedicalHistoryRepository _PatientMedicalHistoryRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly CommonMethods _commonMethods;
        private readonly IPatientApplicationService _patientApplicationService;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IUnitOfWork _unitOfWork;
        public CreatePatientMedicalHistoryHandler(IPatientMedicalHistoryRepository PatientMedicalHistoryRepository, IHttpContextAccessor httpContextAccessor, IPatientApplicationService patientApplicationService,
            IDateTimeProvider dateTimeProvider,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _PatientMedicalHistoryRepository = PatientMedicalHistoryRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _patientApplicationService = patientApplicationService;
            _commonMethods = new CommonMethods(_httpContextAccessor);
            _dateTimeProvider = dateTimeProvider;
            _unitOfWork = unitOfWork;
        }
        public async Task<PatientMedicalHistoryResponseDTO> Handle(CreatePatientMedicalHistoryRequestDTO request,
            CancellationToken cancellationToken)
        {
            PatientMed user = _mapper.Map<PatientMed>(request);
            user.PatientId = _commonMethods.GetClaim(ClaimConstant.ReferenceId);
            user.CreatedBy = Convert.ToInt64(_commonMethods.GetClaim(ClaimTypes.NameIdentifier));
            user.CreatedDate = _dateTimeProvider.PlatformSpecificNow;
            var response = await _PatientMedicalHistoryRepository.Add(user);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<PatientMedicalHistoryResponseDTO>(response);
        }
    }
}
