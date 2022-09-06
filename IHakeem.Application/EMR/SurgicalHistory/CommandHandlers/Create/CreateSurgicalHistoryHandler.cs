using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using iHakeem.Application.EMR.SurgicalHistory.Contracts;
using CurrentMed = iHakeem.Domain.Models.SurgicalHistory;
using iHakeem.Domain.EMR.SurgicalHistory.IDomainRepository;
using MediatR;
using Microsoft.AspNetCore.Http;
using iHakeem.SharedKernal;
using iHakeem.Domain.Patients.IApplicationService;
using System.Security.Claims;
using iHakeem.Infrastructure.Common;
using System;
using iHakeem.Infrastructure.Security.Abstractions;
using iHakeem.SharedKernal.Domain.IUnitOfWork;

namespace iHakeem.Application.EMR.SurgicalHistory.CommandHandlers.Create
{
    public class CreateSurgicalHistoryHandler : IRequestHandler<CreateSurgicalHistoryRequestDTO, SurgicalHistoryResponseDTO>
    {
        private readonly ISurgicalHistoryRepository _SurgicalHistoryRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly CommonMethods _commonMethods;
        private readonly IPatientApplicationService _patientApplicationService;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IUnitOfWork _unitOfWork;
        public CreateSurgicalHistoryHandler(ISurgicalHistoryRepository SurgicalHistoryRepository, IHttpContextAccessor httpContextAccessor, IPatientApplicationService patientApplicationService,
            IDateTimeProvider dateTimeProvider,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _SurgicalHistoryRepository = SurgicalHistoryRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _patientApplicationService = patientApplicationService;
            _commonMethods = new CommonMethods(_httpContextAccessor);
            _dateTimeProvider = dateTimeProvider;
            _unitOfWork = unitOfWork;
        }
        public async Task<SurgicalHistoryResponseDTO> Handle(CreateSurgicalHistoryRequestDTO request,
            CancellationToken cancellationToken)
        {
            CurrentMed user = _mapper.Map<CurrentMed>(request);
            user.PatientId = _commonMethods.GetClaim(ClaimConstant.ReferenceId);
            user.CreatedBy = Convert.ToInt64(_commonMethods.GetClaim(ClaimTypes.NameIdentifier));
            user.CreatedDate = _dateTimeProvider.PlatformSpecificNow;
            var response = await _SurgicalHistoryRepository.Add(user);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<SurgicalHistoryResponseDTO>(response);
        }
    }
}
