using AutoMapper;
using iHakeem.Application.EMR.DetailPregnancies.Contracts;
using PatientFamily=iHakeem.Domain.Models.DetailPregnancies;
using iHakeem.Domain.EMR.DetailPregnancies.IDomainRepository;
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

namespace iHakeem.Application.EMR.DetailPregnancies.CommandHandlers.CreateOrUpdate
{
    public class CreateOrUpdateDetailPregnanciesRequestHandler : IRequestHandler<CreateOrUpdateDetailPregnanciesRequestDTO, DetailPregnanciesResponseDTO>
    {
        private readonly IMapper _mapper;
        private readonly CommonMethods _commonMethods;
        private readonly IDetailPregnanciesRepository _DetailPregnanciesRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDateTimeProvider _dateTimeProvider;

        public CreateOrUpdateDetailPregnanciesRequestHandler(IDetailPregnanciesRepository DetailPregnanciesRepository,
            IMapper mapper, IHttpContextAccessor httpContextAccessor,
            IDateTimeProvider dateTimeProvider,
            IUnitOfWork unitOfWork)
        {
            _DetailPregnanciesRepository = DetailPregnanciesRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _unitOfWork = unitOfWork;
            _dateTimeProvider = dateTimeProvider;
            _commonMethods = new CommonMethods(_httpContextAccessor);
        }
        public async Task<DetailPregnanciesResponseDTO> Handle(CreateOrUpdateDetailPregnanciesRequestDTO request, CancellationToken cancellationToken)
        {
            
            var patientId = _commonMethods.GetClaim(ClaimConstant.ReferenceId);
            if (request.Id > 0)
            {
                var res = await _DetailPregnanciesRepository.GetSingle(request.Id);
                var user = _mapper.Map<PatientFamily>(res);
                var mapResponse = _mapper.Map<CreateOrUpdateDetailPregnanciesRequestDTO, PatientFamily>(request, user);
                mapResponse.UpdatedBy = Convert.ToInt64(_commonMethods.GetClaim(ClaimTypes.NameIdentifier));
                mapResponse.UpdatedDate = _dateTimeProvider.PlatformSpecificNow;
               
                var updatedResponse = _DetailPregnanciesRepository.Update(mapResponse);
                await _unitOfWork.SaveChangesAsync();
                return _mapper.Map<DetailPregnanciesResponseDTO>(updatedResponse);
            }
            var mapped = _mapper.Map<PatientFamily>(request);
            mapped.PatientId = patientId;
            mapped.CreatedBy = Convert.ToInt64(_commonMethods.GetClaim(ClaimTypes.NameIdentifier));
            mapped.CreatedDate = _dateTimeProvider.PlatformSpecificNow;
            var response = await _DetailPregnanciesRepository.Add(mapped);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<DetailPregnanciesResponseDTO>(response);
        }
    }
}
