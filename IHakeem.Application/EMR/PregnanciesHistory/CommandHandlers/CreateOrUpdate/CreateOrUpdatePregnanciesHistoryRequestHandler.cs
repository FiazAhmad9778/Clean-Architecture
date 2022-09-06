using AutoMapper;
using iHakeem.Application.EMR.PregnanciesHistory.Contracts;
using PatientFamily=iHakeem.Domain.Models.PregnanciesHistory;
using iHakeem.Domain.EMR.PregnanciesHistory.IDomainRepository;
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

namespace iHakeem.Application.EMR.PregnanciesHistory.CommandHandlers.CreateOrUpdate
{
    public class CreateOrUpdatePregnanciesHistoryRequestHandler : IRequestHandler<CreateOrUpdatePregnanciesHistoryRequestDTO, PregnanciesHistoryResponseDTO>
    {
        private readonly IMapper _mapper;
        private readonly CommonMethods _commonMethods;
        private readonly IPregnanciesHistoryRepository _PregnanciesHistoryRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDateTimeProvider _dateTimeProvider;

        public CreateOrUpdatePregnanciesHistoryRequestHandler(IPregnanciesHistoryRepository PregnanciesHistoryRepository,
            IMapper mapper, IHttpContextAccessor httpContextAccessor,
            IDateTimeProvider dateTimeProvider,
            IUnitOfWork unitOfWork)
        {
            _PregnanciesHistoryRepository = PregnanciesHistoryRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _unitOfWork = unitOfWork;
            _dateTimeProvider = dateTimeProvider;
            _commonMethods = new CommonMethods(_httpContextAccessor);
        }
        public async Task<PregnanciesHistoryResponseDTO> Handle(CreateOrUpdatePregnanciesHistoryRequestDTO request, CancellationToken cancellationToken)
        {
            
            var patientId = _commonMethods.GetClaim(ClaimConstant.ReferenceId);
            if (request.Id > 0)
            {
                var res = await _PregnanciesHistoryRepository.GetSingle(request.Id);
                var user = _mapper.Map<PatientFamily>(res);
                var mapResponse = _mapper.Map<CreateOrUpdatePregnanciesHistoryRequestDTO, PatientFamily>(request, user);
                mapResponse.UpdatedBy = Convert.ToInt64(_commonMethods.GetClaim(ClaimTypes.NameIdentifier));
                mapResponse.UpdatedDate = _dateTimeProvider.PlatformSpecificNow;
               
                var updatedResponse = _PregnanciesHistoryRepository.Update(mapResponse);
                await _unitOfWork.SaveChangesAsync();
                return _mapper.Map<PregnanciesHistoryResponseDTO>(updatedResponse);
            }
            var mapped = _mapper.Map<PatientFamily>(request);
            mapped.PatientId = patientId;
            mapped.CreatedBy = Convert.ToInt64(_commonMethods.GetClaim(ClaimTypes.NameIdentifier));
            mapped.CreatedDate = _dateTimeProvider.PlatformSpecificNow;
            var response = await _PregnanciesHistoryRepository.Add(mapped);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<PregnanciesHistoryResponseDTO>(response);
        }
    }
}
