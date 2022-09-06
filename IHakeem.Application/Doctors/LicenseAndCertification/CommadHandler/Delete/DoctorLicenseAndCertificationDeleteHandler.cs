using AutoMapper;
using iHakeem.Domain.Doctors.LicenseAndCertification.IDomainRepository;
using iHakeem.SharedKernal.Domain.IUnitOfWork;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.Doctors.LicenseAndCertification.CommadHandler.Delete
{
    public class DoctorLicenseAndCertificationDeleteHandler : IRequestHandler<DoctorLicenseAndCertificationDeleteRequestDTO, bool>
    {
        private readonly IDoctorLicenseAndCertificationRepository _doctorLicenseAndCertificationRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DoctorLicenseAndCertificationDeleteHandler(IDoctorLicenseAndCertificationRepository doctorLicenseAndCertificationRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _doctorLicenseAndCertificationRepository = doctorLicenseAndCertificationRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(DoctorLicenseAndCertificationDeleteRequestDTO request,
            CancellationToken cancellationToken)
        {
            var res = await _doctorLicenseAndCertificationRepository.GetSingle(x => x.Id == request.Id);
            res.IsDeleted = true;
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
