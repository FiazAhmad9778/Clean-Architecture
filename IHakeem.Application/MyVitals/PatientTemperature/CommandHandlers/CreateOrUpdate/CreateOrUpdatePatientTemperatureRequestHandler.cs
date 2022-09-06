using AutoMapper;
using iHakeem.Application.MyVitals.PatientTemperature.Contracts;
using PatientFamily=iHakeem.Domain.Models.PatientTemperature;
using iHakeem.Domain.MyVitals.PatientTemperature.IDomainRepository;
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

namespace iHakeem.Application.MyVitals.PatientTemperature.CommandHandlers.CreateOrUpdate
{
    public class CreateOrUpdatePatientTemperatureRequestHandler : IRequestHandler<CreateOrUpdatePatientTemperatureRequestDTO, PatientTemperatureResponseDTO>
    {
        private readonly IMapper _mapper;
        private readonly CommonMethods _commonMethods;
        private readonly IPatientTemperatureRepository _PatientTemperatureRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDateTimeProvider _dateTimeProvider;

        public CreateOrUpdatePatientTemperatureRequestHandler(IPatientTemperatureRepository PatientTemperatureRepository,
            IMapper mapper, IHttpContextAccessor httpContextAccessor,
            IDateTimeProvider dateTimeProvider,
            IUnitOfWork unitOfWork)
        {
            _PatientTemperatureRepository = PatientTemperatureRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _unitOfWork = unitOfWork;
            _dateTimeProvider = dateTimeProvider;
            _commonMethods = new CommonMethods(_httpContextAccessor);
        }
        public async Task<PatientTemperatureResponseDTO> Handle(CreateOrUpdatePatientTemperatureRequestDTO request, CancellationToken cancellationToken)
        {
            
            var patientId = _commonMethods.GetClaim(ClaimConstant.ReferenceId);
            if (request.Id > 0)
            {
                var res = await _PatientTemperatureRepository.GetSingle(request.Id);
                var user = _mapper.Map<PatientFamily>(res);
                var mapResponse = _mapper.Map<CreateOrUpdatePatientTemperatureRequestDTO, PatientFamily>(request, user);
                mapResponse.UpdatedBy = Convert.ToInt64(_commonMethods.GetClaim(ClaimTypes.NameIdentifier));
                mapResponse.UpdatedDate = _dateTimeProvider.PlatformSpecificNow;
               
                var updatedResponse = _PatientTemperatureRepository.Update(mapResponse);
                await _unitOfWork.SaveChangesAsync();
                return _mapper.Map<PatientTemperatureResponseDTO>(updatedResponse);
            }
            var mapped = _mapper.Map<PatientFamily>(request);
            mapped.PatientId = patientId;
            mapped.CreatedBy = Convert.ToInt64(_commonMethods.GetClaim(ClaimTypes.NameIdentifier));
            mapped.CreatedDate = _dateTimeProvider.PlatformSpecificNow;
            var response = await _PatientTemperatureRepository.Add(mapped);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<PatientTemperatureResponseDTO>(response);
        }
    }
}
