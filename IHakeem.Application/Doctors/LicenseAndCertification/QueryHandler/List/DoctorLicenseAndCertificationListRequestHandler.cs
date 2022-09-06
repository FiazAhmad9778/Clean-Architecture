using AutoMapper;
using iHakeem.Application.Doctors.Education.Contracts;
using iHakeem.Domain.Doctors.LicenseAndCertification.IDomainRepository;
using iHakeem.Infrastructure.Security.Abstractions;
using iHakeem.SharedKernal;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.Doctors.LicenseAndCertification.QueryHandler.List
{
    public class DoctorLicenseAndCertificationRequestHandler : IRequestHandler<DoctorLicenseAndCertificationListRequestDTO, List<DoctorLicenseAndCertificationDTO>>
    {
        private readonly IDoctorLicenseAndCertificationRepository _doctorLicenseAndCertificationRepository;
        private readonly IMapper _mapper;
        private readonly CommonMethods _commonMethods;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DoctorLicenseAndCertificationRequestHandler(IDoctorLicenseAndCertificationRepository doctorLicenseAndCertificationRepository,
            IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _doctorLicenseAndCertificationRepository = doctorLicenseAndCertificationRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _commonMethods = new CommonMethods(_httpContextAccessor);
        }

        public async Task<List<DoctorLicenseAndCertificationDTO>> Handle(DoctorLicenseAndCertificationListRequestDTO query, CancellationToken cancellationToken)
        {
            return _mapper.Map<List<DoctorLicenseAndCertificationDTO>>(await _doctorLicenseAndCertificationRepository.GetAll(x => x.DoctorId == query.DoctorId && x.IsDeleted == false));
        }
    }
}
