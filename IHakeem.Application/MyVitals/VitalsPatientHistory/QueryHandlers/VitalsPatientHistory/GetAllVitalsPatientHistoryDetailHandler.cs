using AutoMapper;
using iHakeem.Application.MyVitals.VitalsPatientHistory.Contracts;
using iHakeem.Database.AppDbContext;
using iHakeem.Domain.EMR.VitalsPatientHistory.IDomainRepository;
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

namespace iHakeem.Application.MyVitals.VitalsPatientHistory.QueryHandlers.Detail
{
    public class GetAllVitalsPatientHistoryDetailHandler : IRequestHandler<GetAllVitalsPatientHistoryDetailRequestDTO, VitalsPatientHistoryResponseDTO>
    {
        private readonly IMapper _mapper;
        private readonly IVitalsPatientHistoryRepository _VitalsPatientHistoryRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly CommonMethods _commonMethods;
        private readonly IVitalsPatientHistoryService _VitalsPatientHistoryService;

        public GetAllVitalsPatientHistoryDetailHandler(IVitalsPatientHistoryRepository VitalsPatientHistoryRepository, IHttpContextAccessor httpContextAccessor, 
            IVitalsPatientHistoryService VitalsPatientHistoryService,
            IMapper mapper)
        {
            _VitalsPatientHistoryRepository = VitalsPatientHistoryRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _VitalsPatientHistoryService = VitalsPatientHistoryService;
            _commonMethods = new CommonMethods(_httpContextAccessor);
        }
        public async Task<VitalsPatientHistoryResponseDTO> Handle(GetAllVitalsPatientHistoryDetailRequestDTO request, CancellationToken cancellationToken)
        {
            GetAllPatientVitalsHistory patientHistory =  new GetAllPatientVitalsHistory();
            var result = await _VitalsPatientHistoryService.GetAllVitalsPatientHistory(patientHistory);
            return _mapper.Map<VitalsPatientHistoryResponseDTO>(result);
        }
    }
}
