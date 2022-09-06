using AutoMapper;
using iHakeem.Application.EMR.CurrentMedication.Contracts;
using iHakeem.Domain.EMR.CurrentMedication.IDomainRepository;
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
using CurrentMed = iHakeem.Domain.Models.CurrentMedication;

namespace iHakeem.Application.EMR.CurrentMedication.CommandHandlers.Edit
{
    public class EditCurrentMedicationHandler : IRequestHandler<EditCurrentMedicationRequestDTO, CurrentMedicationResponseDTO>
    {
        private readonly ICurrentMedicationRepository _currentMedicationRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly CommonMethods _commonMethods;
        private readonly IPatientApplicationService _patientApplicationService;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IUnitOfWork _unitOfWork;
        public EditCurrentMedicationHandler(ICurrentMedicationRepository currentMedicationRepository, IHttpContextAccessor httpContextAccessor, IPatientApplicationService patientApplicationService,
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
        public async Task<CurrentMedicationResponseDTO> Handle(EditCurrentMedicationRequestDTO request,
            CancellationToken cancellationToken)
        {
            var res = await _currentMedicationRepository.GetSingle(request.Id);
            CurrentMed user = _mapper.Map<CurrentMed>(res);
            var mapResponse = _mapper.Map<EditCurrentMedicationRequestDTO, CurrentMed>(request, user);
            mapResponse.UpdatedBy = Convert.ToInt64(_commonMethods.GetClaim(ClaimTypes.NameIdentifier));
            mapResponse.UpdatedDate = _dateTimeProvider.PlatformSpecificNow;
            var updateMedication = _currentMedicationRepository.Update(mapResponse);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<CurrentMedicationResponseDTO>(updateMedication);
        }
    }
}
