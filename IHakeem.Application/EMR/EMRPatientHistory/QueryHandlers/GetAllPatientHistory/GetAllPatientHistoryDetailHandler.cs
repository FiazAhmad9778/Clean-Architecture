using AutoMapper;
using iHakeem.Application.EMR.EMRPatientHistory.Contracts;
using iHakeem.Application.EMR.EMRPatientHistory.QueryHandlers.Detail;
using iHakeem.Database.AppDbContext;
using iHakeem.Domain.EMR.EMRPatientHistory.IDomainRepository;
using iHakeem.Domain.Models;
using iHakeem.Domain.Patients.IApplicationService;
using iHakeem.SharedKernal;
using iHakeem.SharedKernal.AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.EMR.EMRPatientHistory.QueryHandlers.Detail
{
    public class GetAllEMRPatientHistoryDetailHandler : IRequestHandler<GetAllPatientHistoryDetailRequestDTO, EMRPatientHistoryResponseDTO>
    {
        private readonly IMapper _mapper;
        private readonly IEMRPatientHistoryRepository _EMRPatientHistoryRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly CommonMethods _commonMethods;
        private readonly IEMRPatientHistoryService _EMRPatientHistoryService;

        public GetAllEMRPatientHistoryDetailHandler(IEMRPatientHistoryRepository EMRPatientHistoryRepository, IHttpContextAccessor httpContextAccessor, 
            IEMRPatientHistoryService EMRPatientHistoryService,
            IMapper mapper)
        {
            _EMRPatientHistoryRepository = EMRPatientHistoryRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _EMRPatientHistoryService = EMRPatientHistoryService;
            _commonMethods = new CommonMethods(_httpContextAccessor);
        }
        public async Task<EMRPatientHistoryResponseDTO> Handle(GetAllPatientHistoryDetailRequestDTO request, CancellationToken cancellationToken)
        {
            GetAllPatientHistory patientHistory =  new GetAllPatientHistory();
            var result = await _EMRPatientHistoryService.GetAllEMRPatientHistory(patientHistory);
            return _mapper.Map<EMRPatientHistoryResponseDTO>(result);
        }
    }
}
