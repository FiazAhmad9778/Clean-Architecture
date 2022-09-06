using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using iHakeem.Application.EMR.HospitalizationInformation.Contracts;
using iHakeem.Database.AppDbContext;
using CurrentMed = iHakeem.Domain.Models.HospitalizationInformation;
using iHakeem.Domain.EMR.HospitalizationInformation.IDomainRepository;
using iHakeem.Infrastructure.Common.Exceptions;
using MediatR;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Http;
using iHakeem.SharedKernal;
using iHakeem.Domain.Patients.IApplicationService;
using System.Security.Claims;

namespace iHakeem.Application.EMR.HospitalizationInformation.QueryHandlers.Detail
{
    public class GetAllHospitalizationInformationDetailHandler : IRequestHandler<GetAllHospitalizationInformationDetailRequestDTO, List<HospitalizationInformationResponseDTO>>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IHospitalizationInformationRepository _HospitalizationInformationRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly CommonMethods _commonMethods;
        private readonly IPatientApplicationService _patientApplicationService;
        public GetAllHospitalizationInformationDetailHandler(IHospitalizationInformationRepository HospitalizationInformationRepository, ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor, IPatientApplicationService patientApplicationService,
            IMapper mapper)
        {
            _HospitalizationInformationRepository = HospitalizationInformationRepository;
            _dbContext = dbContext;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _patientApplicationService = patientApplicationService;
            _commonMethods = new CommonMethods(_httpContextAccessor);
        }
        public async Task<List<HospitalizationInformationResponseDTO>> Handle(GetAllHospitalizationInformationDetailRequestDTO request, CancellationToken cancellationToken)
        {
            var result = await _patientApplicationService.GetPatientByUserId(_commonMethods.GetClaim(ClaimTypes.NameIdentifier));
            var user = await _HospitalizationInformationRepository.GetAll(s => s.PatientId == result.Id && s.IsDeleted == false);
            return _mapper.Map<List<HospitalizationInformationResponseDTO>>(user);
        }
    }
}
