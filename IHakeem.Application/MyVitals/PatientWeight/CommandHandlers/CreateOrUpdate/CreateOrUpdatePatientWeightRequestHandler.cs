using AutoMapper;
using iHakeem.Application.MyVitals.PatientWeight.Contracts;
using PatientFamily=iHakeem.Domain.Models.PatientWeight;
using iHakeem.Domain.MyVitals.PatientWeight.IDomainRepository;
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

namespace iHakeem.Application.MyVitals.PatientWeight.CommandHandlers.CreateOrUpdate
{
    public class CreateOrUpdatePatientWeightRequestHandler : IRequestHandler<CreateOrUpdatePatientWeightRequestDTO, PatientWeightResponseDTO>
    {
        private readonly IMapper _mapper;
        private readonly CommonMethods _commonMethods;
        private readonly IPatientWeightRepository _PatientWeightRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDateTimeProvider _dateTimeProvider;

        public CreateOrUpdatePatientWeightRequestHandler(IPatientWeightRepository PatientWeightRepository,
            IMapper mapper, IHttpContextAccessor httpContextAccessor,
            IDateTimeProvider dateTimeProvider,
            IUnitOfWork unitOfWork)
        {
            _PatientWeightRepository = PatientWeightRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _unitOfWork = unitOfWork;
            _dateTimeProvider = dateTimeProvider;
            _commonMethods = new CommonMethods(_httpContextAccessor);
        }
        public async Task<PatientWeightResponseDTO> Handle(CreateOrUpdatePatientWeightRequestDTO request, CancellationToken cancellationToken)
        {
            
            var patientId = _commonMethods.GetClaim(ClaimConstant.ReferenceId);
            if (request.Id > 0)
            {
                var res = await _PatientWeightRepository.GetSingle(request.Id);
                var user = _mapper.Map<PatientFamily>(res);
                var mapResponse = _mapper.Map<CreateOrUpdatePatientWeightRequestDTO, PatientFamily>(request, user);
                mapResponse.UpdatedBy = Convert.ToInt64(_commonMethods.GetClaim(ClaimTypes.NameIdentifier));
                mapResponse.UpdatedDate = _dateTimeProvider.PlatformSpecificNow;
               
                var updatedResponse = _PatientWeightRepository.Update(mapResponse);
                await _unitOfWork.SaveChangesAsync();
                return _mapper.Map<PatientWeightResponseDTO>(updatedResponse);
            }
            var mapped = _mapper.Map<PatientFamily>(request);
            mapped.PatientId = patientId;
            mapped.CreatedBy = Convert.ToInt64(_commonMethods.GetClaim(ClaimTypes.NameIdentifier));
            mapped.CreatedDate = _dateTimeProvider.PlatformSpecificNow;
            var response = await _PatientWeightRepository.Add(mapped);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<PatientWeightResponseDTO>(response);
        }
    }
}
