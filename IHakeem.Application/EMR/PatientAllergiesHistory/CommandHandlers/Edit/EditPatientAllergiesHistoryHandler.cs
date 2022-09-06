using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using iHakeem.Application.EMR.PatientAllergiesHistory.Contracts;
using CurrentMed = iHakeem.Domain.Models.PatientAllergiesHistory;
using iHakeem.Domain.EMR.PatientAllergiesHistory.IDomainRepository;
using MediatR;
using Microsoft.AspNetCore.Http;
using iHakeem.SharedKernal;
using iHakeem.Domain.Patients.IApplicationService;
using System.Security.Claims;
using iHakeem.Infrastructure.Common;
using System;
using iHakeem.SharedKernal.Domain.IUnitOfWork;

namespace iHakeem.Application.EMR.PatientAllergiesHistory.CommandHandlers.Edit
{
    public class EditPatientAllergiesHistoryHandler : IRequestHandler<EditPatientAllergiesHistoryRequestDTO, PatientAllergiesHistoryResponseDTO>
    {
        private readonly IPatientAllergiesHistoryRepository _PatientAllergiesHistoryRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly CommonMethods _commonMethods;
        private readonly IPatientApplicationService _patientApplicationService;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IUnitOfWork _unitOfWork;
        public EditPatientAllergiesHistoryHandler(IPatientAllergiesHistoryRepository PatientAllergiesHistoryRepository, IHttpContextAccessor httpContextAccessor, IPatientApplicationService patientApplicationService,
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
        public async Task<PatientAllergiesHistoryResponseDTO> Handle(EditPatientAllergiesHistoryRequestDTO request,
            CancellationToken cancellationToken)
        {
            var res = await _PatientAllergiesHistoryRepository.GetSingle(request.Id);
            CurrentMed user = _mapper.Map<CurrentMed>(res);
            var mapResponse = _mapper.Map<EditPatientAllergiesHistoryRequestDTO, CurrentMed>(request, user);
            mapResponse.UpdatedBy = Convert.ToInt64(_commonMethods.GetClaim(ClaimTypes.NameIdentifier));
            mapResponse.UpdatedDate = _dateTimeProvider.PlatformSpecificNow;
            var updateAllergies = _PatientAllergiesHistoryRepository.Update(mapResponse);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<PatientAllergiesHistoryResponseDTO>(updateAllergies);
        }
    }
}
