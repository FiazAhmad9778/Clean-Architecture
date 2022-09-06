using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using iHakeem.Application.EMR.PharmacyInformation.Contracts;
using CurrentMed = iHakeem.Domain.Models.PharmacyInformation;
using iHakeem.Domain.EMR.PharmacyInformation.IDomainRepository;
using MediatR;
using Microsoft.AspNetCore.Http;
using iHakeem.SharedKernal;
using iHakeem.Domain.Patients.IApplicationService;
using System.Security.Claims;
using System;
using iHakeem.Infrastructure.Common;
using iHakeem.SharedKernal.Domain.IUnitOfWork;

namespace iHakeem.Application.EMR.PharmacyInformation.CommandHandlers.Edit
{
    public class EditPharmacyInformationHandler : IRequestHandler<EditPharmacyInformationRequestDTO, PharmacyInformationResponseDTO>
    {
        private readonly IPharmacyInformationRepository _PharmacyInformationRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly CommonMethods _commonMethods;
        private readonly IPatientApplicationService _patientApplicationService;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IUnitOfWork _unitOfWork;
        public EditPharmacyInformationHandler(IPharmacyInformationRepository PharmacyInformationRepository, IHttpContextAccessor httpContextAccessor, IPatientApplicationService patientApplicationService,
            IDateTimeProvider dateTimeProvider,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _PharmacyInformationRepository = PharmacyInformationRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _patientApplicationService = patientApplicationService;
            _commonMethods = new CommonMethods(_httpContextAccessor);
            _dateTimeProvider = dateTimeProvider;
            _unitOfWork = unitOfWork;
        }
        public async Task<PharmacyInformationResponseDTO> Handle(EditPharmacyInformationRequestDTO request,
            CancellationToken cancellationToken)
        {
            var res = await _PharmacyInformationRepository.GetSingle(request.Id);
            CurrentMed user = _mapper.Map<CurrentMed>(res);
            var mapResponse = _mapper.Map<EditPharmacyInformationRequestDTO, CurrentMed>(request, user);
            mapResponse.UpdatedBy = Convert.ToInt64(_commonMethods.GetClaim(ClaimTypes.NameIdentifier));
            mapResponse.UpdatedDate = _dateTimeProvider.PlatformSpecificNow;
            var updateInformation = _PharmacyInformationRepository.Update(mapResponse);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<PharmacyInformationResponseDTO>(updateInformation);
        }
    }
}
