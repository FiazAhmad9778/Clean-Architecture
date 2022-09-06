using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using iHakeem.Application.EMR.DetailPregnancies.Contracts;
using iHakeem.Database.AppDbContext;
using CurrentMed = iHakeem.Domain.Models.DetailPregnancies;
using iHakeem.Domain.EMR.DetailPregnancies.IDomainRepository;
using iHakeem.Infrastructure.Common.Exceptions;
using MediatR;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Http;
using iHakeem.SharedKernal;
using iHakeem.Domain.Patients.IApplicationService;
using System.Security.Claims;

namespace iHakeem.Application.EMR.DetailPregnancies.QueryHandlers.Detail
{
    public class GetAllDetailPregnanciesDetailHandler : IRequestHandler<GetAllDetailPregnanciesDetailRequestDTO, List<DetailPregnanciesResponseDTO>>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IDetailPregnanciesRepository _DetailPregnanciesRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly CommonMethods _commonMethods;
        private readonly IPatientApplicationService _patientApplicationService;
        public GetAllDetailPregnanciesDetailHandler(IDetailPregnanciesRepository DetailPregnanciesRepository, IHttpContextAccessor httpContextAccessor, IPatientApplicationService patientApplicationService, ApplicationDbContext dbContext,
            IMapper mapper)
        {
            _DetailPregnanciesRepository = DetailPregnanciesRepository;
            _dbContext = dbContext;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _patientApplicationService = patientApplicationService;
            _commonMethods = new CommonMethods(_httpContextAccessor);
        }
        public async Task<List<DetailPregnanciesResponseDTO>> Handle(GetAllDetailPregnanciesDetailRequestDTO request, CancellationToken cancellationToken)
        {
            var result = await _patientApplicationService.GetPatientByUserId(_commonMethods.GetClaim(ClaimTypes.NameIdentifier));
            var user = await _DetailPregnanciesRepository.GetAll(s => s.PatientId == result.Id && s.IsDeleted == false);
            return _mapper.Map<List<DetailPregnanciesResponseDTO>>(user);
        }
    }
}
