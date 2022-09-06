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
using iHakeem.SharedKernal.Domain.IUnitOfWork;

namespace iHakeem.Application.EMR.PatientMedicalHistory.CommandHandlers.Edit
{
    public class EditPatientMedicalHistoryHandler : IRequestHandler<EditPatientMedicalHistoryRequestDTO, PatientMedicalHistoryResponseDTO>
    {
        private readonly IPatientMedicalHistoryRepository _PatientMedicalHistoryRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly CommonMethods _commonMethods;
        private readonly IPatientApplicationService _patientApplicationService;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IUnitOfWork _unitOfWork;
        public EditPatientMedicalHistoryHandler(IPatientMedicalHistoryRepository PatientMedicalHistoryRepository, IHttpContextAccessor httpContextAccessor, IPatientApplicationService patientApplicationService,
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
        public async Task<PatientMedicalHistoryResponseDTO> Handle(EditPatientMedicalHistoryRequestDTO request,
            CancellationToken cancellationToken)
        {
            var res = await _PatientMedicalHistoryRepository.GetSingle(request.Id);
            PatientMed user = _mapper.Map<PatientMed>(res);
            var mapResponse = _mapper.Map<EditPatientMedicalHistoryRequestDTO, PatientMed>(request, user);
            mapResponse.UpdatedBy = Convert.ToInt64(_commonMethods.GetClaim(ClaimTypes.NameIdentifier));
            mapResponse.UpdatedDate = _dateTimeProvider.PlatformSpecificNow;
            var updateMedicalHistory = _PatientMedicalHistoryRepository.Update(mapResponse);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<PatientMedicalHistoryResponseDTO>(updateMedicalHistory);
        }
    }
}
