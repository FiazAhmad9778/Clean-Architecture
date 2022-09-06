using AutoMapper;
using iHakeem.Application.Patients.PatientGaurdians.Contracts;
using iHakeem.Domain.Models;
using iHakeem.Domain.Patients.PatientGaurdians.IDomainRepository;
using iHakeem.Infrastructure.Security.Abstractions;
using iHakeem.SharedKernal;
using iHakeem.SharedKernal.Domain.IUnitOfWork;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.Patients.PatientGaurdians.CommandHandlers.CreateOrUpdate
{
    public class CreatePatientSocialInformationRequestHandler : IRequestHandler<CreateOrUpdatePatientGaurdianRequestDTO, PatientGaurdianResponseDTO>
    {
        private readonly IMapper _mapper;
        private readonly CommonMethods _commonMethods;
        private readonly IPatientGaurdianRepository _patientGaurdianRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnitOfWork _unitOfWork;

        public CreatePatientSocialInformationRequestHandler(IPatientGaurdianRepository patientGaurdianRepository,
            IMapper mapper, IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork)
        {
            _patientGaurdianRepository = patientGaurdianRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _unitOfWork = unitOfWork;
            _commonMethods = new CommonMethods(_httpContextAccessor);
        }
        public async Task<Contracts.PatientGaurdianResponseDTO> Handle(CreateOrUpdatePatientGaurdianRequestDTO request, CancellationToken cancellationToken)
        {
            var mapped = _mapper.Map<PatientGaurdian>(request);
            var patientId = _commonMethods.GetClaim(ClaimConstant.ReferenceId);
            if (mapped.Id > 0)
            {
                var updatedResponse = _patientGaurdianRepository.Update(mapped);
                await _unitOfWork.SaveChangesAsync();
                return _mapper.Map<Contracts.PatientGaurdianResponseDTO>(updatedResponse);
            }
            mapped.PatientId = patientId;
            var response = await _patientGaurdianRepository.Add(mapped);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<Contracts.PatientGaurdianResponseDTO>(response);
        }
    }
}
