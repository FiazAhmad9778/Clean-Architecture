using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using iHakeem.Application.EMR.RecreationalDrugsHistory.Contracts;
using CurrentMed = iHakeem.Domain.Models.RecreationalDrugsHistory;
using iHakeem.Domain.EMR.RecreationalDrugsHistory.IDomainRepository;
using MediatR;
using Microsoft.AspNetCore.Http;
using iHakeem.SharedKernal;
using iHakeem.Domain.Patients.IApplicationService;
using System.Security.Claims;
using System;
using iHakeem.Infrastructure.Common;
using iHakeem.Infrastructure.Security.Abstractions;
using iHakeem.SharedKernal.Domain.IUnitOfWork;

namespace iHakeem.Application.EMR.RecreationalDrugsHistory.CommandHandlers.Create
{
    public class CreateRecreationalDrugsHistoryHandler : IRequestHandler<CreateRecreationalDrugsHistoryRequestDTO, RecreationalDrugsHistoryResponseDTO>
    {
        private readonly IRecreationalDrugsHistoryRepository _RecreationalDrugsHistoryRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly CommonMethods _commonMethods;
        private readonly IPatientApplicationService _patientApplicationService;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IUnitOfWork _unitOfWork;
        public CreateRecreationalDrugsHistoryHandler(IRecreationalDrugsHistoryRepository RecreationalDrugsHistoryRepository, IHttpContextAccessor httpContextAccessor, IPatientApplicationService patientApplicationService,
            IDateTimeProvider dateTimeProvider,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _RecreationalDrugsHistoryRepository = RecreationalDrugsHistoryRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _patientApplicationService = patientApplicationService;
            _commonMethods = new CommonMethods(_httpContextAccessor);
            _dateTimeProvider = dateTimeProvider;
            _unitOfWork = unitOfWork;
        }
        public async Task<RecreationalDrugsHistoryResponseDTO> Handle(CreateRecreationalDrugsHistoryRequestDTO request,
            CancellationToken cancellationToken)
        {
            CurrentMed user = _mapper.Map<CurrentMed>(request);
            user.PatientId = _commonMethods.GetClaim(ClaimConstant.ReferenceId);
            user.CreatedBy = Convert.ToInt64(_commonMethods.GetClaim(ClaimTypes.NameIdentifier));
            user.CreatedDate = _dateTimeProvider.PlatformSpecificNow;
            var response = await _RecreationalDrugsHistoryRepository.Add(user);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<RecreationalDrugsHistoryResponseDTO>(response);
        }
    }
}
