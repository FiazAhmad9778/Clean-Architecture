using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using iHakeem.Application.EMR.HospitalizationInformation.Contracts;
using CurrentMed = iHakeem.Domain.Models.HospitalizationInformation;
using iHakeem.Domain.EMR.HospitalizationInformation.IDomainRepository;
using MediatR;
using Microsoft.AspNetCore.Http;
using iHakeem.SharedKernal;
using iHakeem.Domain.Patients.IApplicationService;
using System.Security.Claims;
using iHakeem.Infrastructure.Common;
using System;
using iHakeem.SharedKernal.Domain.IUnitOfWork;

namespace iHakeem.Application.EMR.HospitalizationInformation.CommandHandlers.Edit
{
    public class EditHospitalizationInformationHandler : IRequestHandler<EditHospitalizationInformationRequestDTO, HospitalizationInformationResponseDTO>
    {
        private readonly IHospitalizationInformationRepository _HospitalizationInformationRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly CommonMethods _commonMethods;
        private readonly IPatientApplicationService _patientApplicationService;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IUnitOfWork _unitOfWork;
        public EditHospitalizationInformationHandler(IHospitalizationInformationRepository HospitalizationInformationRepository, IHttpContextAccessor httpContextAccessor, IPatientApplicationService patientApplicationService,
            IDateTimeProvider dateTimeProvider,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _HospitalizationInformationRepository = HospitalizationInformationRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _patientApplicationService = patientApplicationService;
            _commonMethods = new CommonMethods(_httpContextAccessor);
            _dateTimeProvider = dateTimeProvider;
            _unitOfWork = unitOfWork;
        }
        public async Task<HospitalizationInformationResponseDTO> Handle(EditHospitalizationInformationRequestDTO request,
            CancellationToken cancellationToken)
        {
            var res = await _HospitalizationInformationRepository.GetSingle(request.Id);
            CurrentMed user = _mapper.Map<CurrentMed>(res);
            var mapResponse = _mapper.Map<EditHospitalizationInformationRequestDTO, CurrentMed>(request, user);
            mapResponse.UpdatedBy = Convert.ToInt64(_commonMethods.GetClaim(ClaimTypes.NameIdentifier));
            mapResponse.UpdatedDate = _dateTimeProvider.PlatformSpecificNow;
            var updateHosp =_HospitalizationInformationRepository.Update(mapResponse);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<HospitalizationInformationResponseDTO>(updateHosp);
        }
    }
}
