using AutoMapper;
using iHakeem.Application.EMR.PatientFamilyHistory.Contracts;
using PatientFamily=iHakeem.Domain.Models.PatientFamilyHistory;
using iHakeem.Domain.EMR.PatientFamilyHistory.IDomainRepository;
using iHakeem.Infrastructure.Security.Abstractions;
using iHakeem.SharedKernal;
using iHakeem.SharedKernal.Domain.IUnitOfWork;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using iHakeem.Infrastructure.Common;
using System.Security.Claims;

namespace iHakeem.Application.EMR.PatientFamilyHistory.CommandHandlers.CreateOrUpdate
{
    public class CreateOrUpdatePatientFamilyHistoryRequestHandler : IRequestHandler<CreateOrUpdatePatientFamilyHistoryRequestDTO, PatientFamilyHistoryResponseDTO>
    {
        private readonly IMapper _mapper;
        private readonly CommonMethods _commonMethods;
        private readonly IPatientFamilyHistoryRepository _PatientFamilyHistoryRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDateTimeProvider _dateTimeProvider;

        public CreateOrUpdatePatientFamilyHistoryRequestHandler(IPatientFamilyHistoryRepository PatientFamilyHistoryRepository,
            IMapper mapper, IHttpContextAccessor httpContextAccessor,
            IDateTimeProvider dateTimeProvider,
            IUnitOfWork unitOfWork)
        {
            _PatientFamilyHistoryRepository = PatientFamilyHistoryRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _unitOfWork = unitOfWork;
            _dateTimeProvider = dateTimeProvider;
            _commonMethods = new CommonMethods(_httpContextAccessor);
        }
        public async Task<PatientFamilyHistoryResponseDTO> Handle(CreateOrUpdatePatientFamilyHistoryRequestDTO request, CancellationToken cancellationToken)
        {
            
            var patientId = _commonMethods.GetClaim(ClaimConstant.ReferenceId);
            if (request.Id > 0)
            {
                var res = await _PatientFamilyHistoryRepository.GetSingle(request.Id);
                var user = _mapper.Map<PatientFamily>(res);
                var mapResponse = _mapper.Map<CreateOrUpdatePatientFamilyHistoryRequestDTO, PatientFamily>(request, user);
                mapResponse.UpdatedBy = Convert.ToInt64(_commonMethods.GetClaim(ClaimTypes.NameIdentifier));
                mapResponse.UpdatedDate = _dateTimeProvider.PlatformSpecificNow;
               
                var updatedResponse = _PatientFamilyHistoryRepository.Update(mapResponse);
                await _unitOfWork.SaveChangesAsync();
                return _mapper.Map<PatientFamilyHistoryResponseDTO>(updatedResponse);
            }
            var mapped = _mapper.Map<PatientFamily>(request);
            mapped.PatientId = patientId;
            mapped.CreatedBy = Convert.ToInt64(_commonMethods.GetClaim(ClaimTypes.NameIdentifier));
            mapped.CreatedDate = _dateTimeProvider.PlatformSpecificNow;
            var response = await _PatientFamilyHistoryRepository.Add(mapped);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<PatientFamilyHistoryResponseDTO>(response);
        }
    }
}
