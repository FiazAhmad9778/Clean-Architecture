using AutoMapper;
using iHakeem.Application.EMR.SocialHistory.Contracts;
using iHakeem.Domain.EMR.SocialHistory.IDomainRepository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using CurrentMed = iHakeem.Domain.Models.SocialHistory;
using Microsoft.AspNetCore.Http;
using iHakeem.SharedKernal;
using iHakeem.Domain.Patients.IApplicationService;
using System.Security.Claims;
using System;
using iHakeem.Infrastructure.Common;
using iHakeem.Infrastructure.Security.Abstractions;
using iHakeem.SharedKernal.Domain.IUnitOfWork;

namespace iHakeem.Application.EMR.SocialHistory.CommandHandlers.Create
{
    public class CreateSocialHistoryHandler : IRequestHandler<CreateSocialHistoryRequestDTO, SocialHistoryResponseDTO>
    {
        private readonly ISocialHistoryRepository _SocialHistoryRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly CommonMethods _commonMethods;
        private readonly IPatientApplicationService _patientApplicationService;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IUnitOfWork _unitOfWork;
        public CreateSocialHistoryHandler(ISocialHistoryRepository SocialHistoryRepository, IHttpContextAccessor httpContextAccessor, IPatientApplicationService patientApplicationService,
            IDateTimeProvider dateTimeProvider,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _SocialHistoryRepository = SocialHistoryRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _patientApplicationService = patientApplicationService;
            _commonMethods = new CommonMethods(_httpContextAccessor);
            _dateTimeProvider = dateTimeProvider;
            _unitOfWork = unitOfWork;
        }
        public async Task<SocialHistoryResponseDTO> Handle(CreateSocialHistoryRequestDTO request,
            CancellationToken cancellationToken)
        {
            CurrentMed user = _mapper.Map<CurrentMed>(request);
            user.PatientId = _commonMethods.GetClaim(ClaimConstant.ReferenceId);
            user.CreatedBy = Convert.ToInt64(_commonMethods.GetClaim(ClaimTypes.NameIdentifier));
            user.CreatedDate = _dateTimeProvider.PlatformSpecificNow;
            var response = await _SocialHistoryRepository.Add(user);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<SocialHistoryResponseDTO>(response);
        }
    }
}
