﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using iHakeem.Application.MyVitals.PatientWeight.Contracts;
using iHakeem.Database.AppDbContext;
using CurrentMed = iHakeem.Domain.Models.PatientWeight;
using iHakeem.Domain.MyVitals.PatientWeight.IDomainRepository;
using iHakeem.Infrastructure.Common.Exceptions;
using MediatR;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Http;
using iHakeem.SharedKernal;
using iHakeem.Domain.Patients.IApplicationService;
using System.Security.Claims;

namespace iHakeem.Application.MyVitals.PatientWeight.QueryHandlers.Detail
{
    public class GetAllPatientWeightDetailHandler : IRequestHandler<GetAllPatientWeightDetailRequestDTO, List<PatientWeightResponseDTO>>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IPatientWeightRepository _PatientWeightRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly CommonMethods _commonMethods;
        private readonly IPatientApplicationService _patientApplicationService;
        public GetAllPatientWeightDetailHandler(IPatientWeightRepository PatientWeightRepository, IHttpContextAccessor httpContextAccessor, IPatientApplicationService patientApplicationService, ApplicationDbContext dbContext,
            IMapper mapper)
        {
            _PatientWeightRepository = PatientWeightRepository;
            _dbContext = dbContext;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _patientApplicationService = patientApplicationService;
            _commonMethods = new CommonMethods(_httpContextAccessor);
        }
        public async Task<List<PatientWeightResponseDTO>> Handle(GetAllPatientWeightDetailRequestDTO request, CancellationToken cancellationToken)
        {
            var result = await _patientApplicationService.GetPatientByUserId(_commonMethods.GetClaim(ClaimTypes.NameIdentifier));
            var user = await _PatientWeightRepository.GetAll(s => s.PatientId == result.Id && s.IsDeleted == false);
            return _mapper.Map<List<PatientWeightResponseDTO>>(user);
        }
    }
}
