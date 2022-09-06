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
using iHakeem.SharedKernal.Domain.IUnitOfWork;

namespace iHakeem.Application.EMR.SocialHistory.CommandHandlers.Edit
{
    public class EditSocialHistoryHandler : IRequestHandler<EditSocialHistoryRequestDTO, SocialHistoryResponseDTO>
    {
        private readonly ISocialHistoryRepository _SocialHistoryRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly CommonMethods _commonMethods;
        private readonly IPatientApplicationService _patientApplicationService;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IUnitOfWork _unitOfWork;
        public EditSocialHistoryHandler(ISocialHistoryRepository SocialHistoryRepository, IHttpContextAccessor httpContextAccessor, IPatientApplicationService patientApplicationService,
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
        public async Task<SocialHistoryResponseDTO> Handle(EditSocialHistoryRequestDTO request,
            CancellationToken cancellationToken)
        {
            var res = await _SocialHistoryRepository.GetSingle(request.Id);
            CurrentMed user = _mapper.Map<CurrentMed>(res);
            var mapResponse = _mapper.Map<EditSocialHistoryRequestDTO, CurrentMed>(request, user);
            mapResponse.UpdatedBy = Convert.ToInt64(_commonMethods.GetClaim(ClaimTypes.NameIdentifier));
            mapResponse.UpdatedDate = _dateTimeProvider.PlatformSpecificNow;
            var updateSocial = _SocialHistoryRepository.Update(mapResponse);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<SocialHistoryResponseDTO>(updateSocial);
        }
    }
}
