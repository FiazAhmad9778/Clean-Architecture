using AutoMapper;
using iHakeem.Application.Doctors.Education.Contracts;
using iHakeem.Database.AppDbContext;
using iHakeem.Domain.Doctors.LicenseAndCertification.IDomainRepository;
using iHakeem.Infrastructure.Security.Abstractions;
using iHakeem.SharedKernal;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.Doctors.LicenseAndCertification.QueryHandler.Detail
{
    public class DoctorLicenseAndCertificationDetailHandler : IRequestHandler<DoctorLicenseAndCertificationDetailRequestDTO, DoctorLicenseAndCertificationDTO>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly CommonMethods _commonMethods;
        private readonly IDoctorLicenseAndCertificationRepository _doctorLicenseAndCertificationRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DoctorLicenseAndCertificationDetailHandler(IDoctorLicenseAndCertificationRepository doctorLicenseAndCertificationRepository, ApplicationDbContext dbContext,
            IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _doctorLicenseAndCertificationRepository = doctorLicenseAndCertificationRepository;
            _dbContext = dbContext;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _commonMethods = new CommonMethods(_httpContextAccessor);
        }
        public async Task<DoctorLicenseAndCertificationDTO> Handle(DoctorLicenseAndCertificationDetailRequestDTO request, CancellationToken cancellationToken)
        {
            var user = await _doctorLicenseAndCertificationRepository.GetSingle(x => x.Id == request.Id && x.IsDeleted == false);
            return _mapper.Map<DoctorLicenseAndCertificationDTO>(user);
        }
    }
}
