using AutoMapper;
using iHakeem.Application.EMR.CurrentMedication.Contracts;
using iHakeem.Database.AppDbContext;
using iHakeem.Domain.EMR.CurrentMedication.IDomainRepository;
using iHakeem.Domain.Patients.IApplicationService;
using iHakeem.SharedKernal;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.EMR.CurrentMedication.QueryHandlers.Detail
{
    public class GetAllCurrentMedicationDetailHandler : IRequestHandler<GetAllCurrentMedicationDetailRequestDTO, List<CurrentMedicationResponseDTO>>
    {
        private readonly IMapper _mapper;
        private readonly ICurrentMedicationRepository _currentMedicationRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly CommonMethods _commonMethods;
        private readonly IPatientApplicationService _patientApplicationService;

        public GetAllCurrentMedicationDetailHandler(ICurrentMedicationRepository currentMedicationRepository, IHttpContextAccessor httpContextAccessor, IPatientApplicationService patientApplicationService,
            IMapper mapper)
        {
            _currentMedicationRepository = currentMedicationRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _patientApplicationService = patientApplicationService;
            _commonMethods = new CommonMethods(_httpContextAccessor);
        }
        public async Task<List<CurrentMedicationResponseDTO>> Handle(GetAllCurrentMedicationDetailRequestDTO request, CancellationToken cancellationToken)
        {
            var result = await _patientApplicationService.GetPatientByUserId(_commonMethods.GetClaim(ClaimTypes.NameIdentifier));
            var user = await _currentMedicationRepository.GetAll(s=>s.PatientId == result.Id && s.IsDeleted == false);
            return _mapper.Map<List<CurrentMedicationResponseDTO>>(user);
        }
    }
}
