using AutoMapper;
using iHakeem.Application.EMR.PatientHobbiesHistory.Contracts;
using PatientFamily=iHakeem.Domain.Models.PatientHobbiesHistory;
using iHakeem.Domain.EMR.PatientHobbiesHistory.IDomainRepository;
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

namespace iHakeem.Application.EMR.PatientHobbiesHistory.CommandHandlers.CreateOrUpdate
{
    public class CreateOrUpdatePatientHobbiesHistoryRequestHandler : IRequestHandler<CreateOrUpdatePatientHobbiesHistoryRequestDTO, PatientHobbiesHistoryResponseDTO>
    {
        private readonly IMapper _mapper;
        private readonly CommonMethods _commonMethods;
        private readonly IPatientHobbiesHistoryRepository _PatientHobbiesHistoryRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDateTimeProvider _dateTimeProvider;

        public CreateOrUpdatePatientHobbiesHistoryRequestHandler(IPatientHobbiesHistoryRepository PatientHobbiesHistoryRepository,
            IMapper mapper, IHttpContextAccessor httpContextAccessor,
            IDateTimeProvider dateTimeProvider,
            IUnitOfWork unitOfWork)
        {
            _PatientHobbiesHistoryRepository = PatientHobbiesHistoryRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _unitOfWork = unitOfWork;
            _dateTimeProvider = dateTimeProvider;
            _commonMethods = new CommonMethods(_httpContextAccessor);
        }
        public async Task<PatientHobbiesHistoryResponseDTO> Handle(CreateOrUpdatePatientHobbiesHistoryRequestDTO request, CancellationToken cancellationToken)
        {
            
            var patientId = _commonMethods.GetClaim(ClaimConstant.ReferenceId);
            if (request.Id > 0)
            {
                var res = await _PatientHobbiesHistoryRepository.GetSingle(request.Id);
                var user = _mapper.Map<PatientFamily>(res);
                var mapResponse = _mapper.Map<CreateOrUpdatePatientHobbiesHistoryRequestDTO, PatientFamily>(request, user);
                mapResponse.UpdatedBy = Convert.ToInt64(_commonMethods.GetClaim(ClaimTypes.NameIdentifier));
                mapResponse.UpdatedDate = _dateTimeProvider.PlatformSpecificNow;
               
                var updatedResponse = _PatientHobbiesHistoryRepository.Update(mapResponse);
                await _unitOfWork.SaveChangesAsync();
                return _mapper.Map<PatientHobbiesHistoryResponseDTO>(updatedResponse);
            }
            var mapped = _mapper.Map<PatientFamily>(request);
            mapped.PatientId = patientId;
            mapped.CreatedBy = Convert.ToInt64(_commonMethods.GetClaim(ClaimTypes.NameIdentifier));
            mapped.CreatedDate = _dateTimeProvider.PlatformSpecificNow;
            var response = await _PatientHobbiesHistoryRepository.Add(mapped);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<PatientHobbiesHistoryResponseDTO>(response);
        }
    }
}
