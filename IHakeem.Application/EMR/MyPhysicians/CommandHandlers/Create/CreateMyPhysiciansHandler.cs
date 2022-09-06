using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using iHakeem.Application.EMR.MyPhysicians.Contracts;
using CurrentMed = iHakeem.Domain.Models.MyPhysicians;
using iHakeem.Domain.EMR.MyPhysicians.IDomainRepository;
using MediatR;
using Microsoft.AspNetCore.Http;
using iHakeem.SharedKernal;
using iHakeem.Domain.Patients.IApplicationService;
using System.Security.Claims;
using iHakeem.Infrastructure.Common;
using System;
using iHakeem.Infrastructure.Security.Abstractions;
using iHakeem.SharedKernal.Domain.IUnitOfWork;

namespace iHakeem.Application.EMR.MyPhysicians.CommandHandlers.Create
{
    public class CreateMyPhysiciansHandler : IRequestHandler<CreateMyPhysiciansRequestDTO, MyPhysiciansResponseDTO>
    {
        private readonly IMyPhysiciansRepository _MyPhysiciansRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly CommonMethods _commonMethods;
        private readonly IPatientApplicationService _patientApplicationService;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IUnitOfWork _unitOfWork;
        public CreateMyPhysiciansHandler(IMyPhysiciansRepository MyPhysiciansRepository, IHttpContextAccessor httpContextAccessor, IPatientApplicationService patientApplicationService,
            IDateTimeProvider dateTimeProvider,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _MyPhysiciansRepository = MyPhysiciansRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _patientApplicationService = patientApplicationService;
            _commonMethods = new CommonMethods(_httpContextAccessor);
            _dateTimeProvider = dateTimeProvider;
            _unitOfWork = unitOfWork;
        }
        public async Task<MyPhysiciansResponseDTO> Handle(CreateMyPhysiciansRequestDTO request,
            CancellationToken cancellationToken)
        {
            CurrentMed user = _mapper.Map<CurrentMed>(request);
            user.PatientId = _commonMethods.GetClaim(ClaimConstant.ReferenceId);
            user.CreatedBy = Convert.ToInt64(_commonMethods.GetClaim(ClaimTypes.NameIdentifier));
            user.CreatedDate = _dateTimeProvider.PlatformSpecificNow;
            var response = await _MyPhysiciansRepository.Add(user);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<MyPhysiciansResponseDTO>(response);
        }
    }
}
