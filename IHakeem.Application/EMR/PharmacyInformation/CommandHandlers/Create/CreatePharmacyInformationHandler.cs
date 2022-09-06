using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using iHakeem.Application.EMR.PharmacyInformation.Contracts;
using Pharmacy = iHakeem.Domain.Models.PharmacyInformation;
using iHakeem.Domain.EMR.PharmacyInformation.IDomainRepository;
using MediatR;
using Microsoft.AspNetCore.Http;
using iHakeem.SharedKernal;
using iHakeem.Domain.Patients.IApplicationService;
using System.Security.Claims;
using iHakeem.Infrastructure.Common;
using System;
using iHakeem.Infrastructure.Security.Abstractions;
using iHakeem.SharedKernal.Domain.IUnitOfWork;

namespace iHakeem.Application.EMR.PharmacyInformation.CommandHandlers.Create
{
    public class CreatePharmacyInformationHandler : IRequestHandler<CreatePharmacyInformationRequestDTO, PharmacyInformationResponseDTO>
    {
        private readonly IPharmacyInformationRepository _PharmacyInformationRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly CommonMethods _commonMethods;
        private readonly IPatientApplicationService _patientApplicationService;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IUnitOfWork _unitOfWork;
        public CreatePharmacyInformationHandler(IPharmacyInformationRepository PharmacyInformationRepository, IHttpContextAccessor httpContextAccessor, IPatientApplicationService patientApplicationService,
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
        public async Task<PharmacyInformationResponseDTO> Handle(CreatePharmacyInformationRequestDTO request,
            CancellationToken cancellationToken)
        {
            Pharmacy user = _mapper.Map<Pharmacy>(request);
            user.PatientId = _commonMethods.GetClaim(ClaimConstant.ReferenceId);
            user.CreatedBy = Convert.ToInt64(_commonMethods.GetClaim(ClaimTypes.NameIdentifier));
            user.CreatedDate = _dateTimeProvider.PlatformSpecificNow;
            var response = await _PharmacyInformationRepository.Add(user);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<PharmacyInformationResponseDTO>(response);
        }
    }
}
