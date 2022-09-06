using AutoMapper;
using iHakeem.Application.EMR.PatientAllergiesHistory.Contracts;
using iHakeem.Domain.EMR.PatientAllergiesHistory.IDomainRepository;
using iHakeem.Domain.Patients.IApplicationService;
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
using CurrentMed = iHakeem.Domain.Models.PatientAllergiesHistory;

namespace iHakeem.Application.EMR.PatientAllergiesHistory.CommandHandlers.Create
{
    public class CreatePatientAllergiesHistoryHandler : IRequestHandler<CreatePatientAllergiesHistoryRequestDTO, PatientAllergiesHistoryResponseDTO>
    {
        private readonly IPatientAllergiesHistoryRepository _PatientAllergiesHistoryRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly CommonMethods _commonMethods;
        private readonly IPatientApplicationService _patientApplicationService;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IUnitOfWork _unitOfWork;
        public CreatePatientAllergiesHistoryHandler(IPatientAllergiesHistoryRepository PatientAllergiesHistoryRepository, IHttpContextAccessor httpContextAccessor, IPatientApplicationService patientApplicationService,
            IDateTimeProvider dateTimeProvider,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _PatientAllergiesHistoryRepository = PatientAllergiesHistoryRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _patientApplicationService = patientApplicationService;
            _commonMethods = new CommonMethods(_httpContextAccessor);
            _dateTimeProvider = dateTimeProvider;
            _unitOfWork = unitOfWork;
        }
        public async Task<PatientAllergiesHistoryResponseDTO> Handle(CreatePatientAllergiesHistoryRequestDTO request,
            CancellationToken cancellationToken)
        {
            CurrentMed user = _mapper.Map<CurrentMed>(request);
            user.PatientId = _commonMethods.GetClaim(ClaimConstant.ReferenceId);
            user.CreatedBy = Convert.ToInt64(_commonMethods.GetClaim(ClaimTypes.NameIdentifier));
            user.CreatedDate = _dateTimeProvider.PlatformSpecificNow;
            var response = await _PatientAllergiesHistoryRepository.Add(user);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<PatientAllergiesHistoryResponseDTO>(response);
        }
    }
}
