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
using iHakeem.SharedKernal.Domain.IUnitOfWork;

namespace iHakeem.Application.EMR.SurgicalHistory.CommandHandlers.Edit
{
    public class EditSurgicalHistoryHandler : IRequestHandler<EditSurgicalHistoryRequestDTO, SurgicalHistoryResponseDTO>
    {
        private readonly ISurgicalHistoryRepository _SurgicalHistoryRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly CommonMethods _commonMethods;
        private readonly IPatientApplicationService _patientApplicationService;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IUnitOfWork _unitOfWork;
        public EditSurgicalHistoryHandler(ISurgicalHistoryRepository SurgicalHistoryRepository, IHttpContextAccessor httpContextAccessor, IPatientApplicationService patientApplicationService,
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
        public async Task<SurgicalHistoryResponseDTO> Handle(EditSurgicalHistoryRequestDTO request,
            CancellationToken cancellationToken)
        {
            var res = await _SurgicalHistoryRepository.GetSingle(request.Id);
            CurrentMed user = _mapper.Map<CurrentMed>(res);
            var mapResponse = _mapper.Map<EditSurgicalHistoryRequestDTO, CurrentMed>(request, user);
            mapResponse.UpdatedBy = Convert.ToInt64(_commonMethods.GetClaim(ClaimTypes.NameIdentifier));
            mapResponse.UpdatedDate = _dateTimeProvider.PlatformSpecificNow;
            var updateSurgical = _SurgicalHistoryRepository.Update(mapResponse);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<SurgicalHistoryResponseDTO>(updateSurgical);
        }
    }
}
