using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using iHakeem.Application.EMR.HospitalizationInformation.Contracts;
using Hospital = iHakeem.Domain.Models.HospitalizationInformation;
using iHakeem.Domain.EMR.HospitalizationInformation.IDomainRepository;
using MediatR;
using Microsoft.AspNetCore.Http;
using iHakeem.SharedKernal;
using iHakeem.Domain.Patients.IApplicationService;
using System.Security.Claims;
using System;
using iHakeem.Infrastructure.Common;
using iHakeem.Infrastructure.Security.Abstractions;
using iHakeem.SharedKernal.Domain.IUnitOfWork;

namespace iHakeem.Application.EMR.HospitalizationInformation.CommandHandlers.Create
{
    public class CreateHospitalizationInformationHandler : IRequestHandler<CreateHospitalizationInformationRequestDTO, HospitalizationInformationResponseDTO>
    {
        private readonly IHospitalizationInformationRepository _HospitalizationInformationRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly CommonMethods _commonMethods;
        private readonly IPatientApplicationService _patientApplicationService;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IUnitOfWork _unitOfWork;
        public CreateHospitalizationInformationHandler(IHospitalizationInformationRepository HospitalizationInformationRepository, IHttpContextAccessor httpContextAccessor, IPatientApplicationService patientApplicationService,
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
        public async Task<HospitalizationInformationResponseDTO> Handle(CreateHospitalizationInformationRequestDTO request,
            CancellationToken cancellationToken)
        {
            Hospital user = _mapper.Map<Hospital>(request);
            user.PatientId = _commonMethods.GetClaim(ClaimConstant.ReferenceId);
            user.CreatedBy = Convert.ToInt64(_commonMethods.GetClaim(ClaimTypes.NameIdentifier));
            user.CreatedDate = _dateTimeProvider.PlatformSpecificNow;
            var response = await _HospitalizationInformationRepository.Add(user);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<HospitalizationInformationResponseDTO>(response);
        }
    }
}
