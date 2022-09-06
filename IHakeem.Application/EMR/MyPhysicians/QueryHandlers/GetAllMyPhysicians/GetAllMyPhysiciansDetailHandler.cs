using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using iHakeem.Application.EMR.MyPhysicians.Contracts;
using iHakeem.Database.AppDbContext;
using CurrentMed = iHakeem.Domain.Models.MyPhysicians;
using iHakeem.Domain.EMR.MyPhysicians.IDomainRepository;
using iHakeem.Infrastructure.Common.Exceptions;
using MediatR;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Http;
using iHakeem.SharedKernal;
using iHakeem.Domain.Patients.IApplicationService;
using System.Security.Claims;

namespace iHakeem.Application.EMR.MyPhysicians.QueryHandlers.Detail
{
    public class GetAllMyPhysiciansDetailHandler : IRequestHandler<GetAllMyPhysiciansDetailRequestDTO, List<MyPhysiciansResponseDTO>>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IMyPhysiciansRepository _MyPhysiciansRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly CommonMethods _commonMethods;
        private readonly IPatientApplicationService _patientApplicationService;
        public GetAllMyPhysiciansDetailHandler(IMyPhysiciansRepository MyPhysiciansRepository, ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor, IPatientApplicationService patientApplicationService,
            IMapper mapper)
        {
            _MyPhysiciansRepository = MyPhysiciansRepository;
            _dbContext = dbContext;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _patientApplicationService = patientApplicationService;
            _commonMethods = new CommonMethods(_httpContextAccessor);
        }
        public async Task<List<MyPhysiciansResponseDTO>> Handle(GetAllMyPhysiciansDetailRequestDTO request, CancellationToken cancellationToken)
        {
            var result = await _patientApplicationService.GetPatientByUserId(_commonMethods.GetClaim(ClaimTypes.NameIdentifier));
            var user = await _MyPhysiciansRepository.GetAll(s => s.PatientId == result.Id && s.IsDeleted == false);
            return _mapper.Map<List<MyPhysiciansResponseDTO>>(user);
        }
    }
}
