using AutoMapper;
using iHakeem.Application.Doctors.Education.Contracts;
using iHakeem.Domain.Doctors.LicenseAndCertification.IDomainRepository;
using iHakeem.Domain.Models;
using iHakeem.SharedKernal.Domain.IUnitOfWork;
using MAP.Common.Extensions;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.Doctors.LicenseAndCertification.CommadHandler.Create
{
    public class DoctorLicenseAndCertificationRequestHandler : IRequestHandler<DoctorLicenseAndCertificationCreateRequestDTO, DoctorLicenseAndCertificationDTO>
    {
        private readonly IDoctorLicenseAndCertificationRepository _doctorLicenseAndCertificationRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DoctorLicenseAndCertificationRequestHandler(IDoctorLicenseAndCertificationRepository doctorLicenseAndCertificationRepository,
            IMapper mapper, IUnitOfWork unitOfWork)
        {
            _doctorLicenseAndCertificationRepository = doctorLicenseAndCertificationRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<DoctorLicenseAndCertificationDTO> Handle(DoctorLicenseAndCertificationCreateRequestDTO request, CancellationToken cancellationToken)
        {

            var doctorLicenseAndCertificationDTO = _mapper.Map<DoctorLicenseAndCertification>(request);
            if (doctorLicenseAndCertificationDTO != null)
            {
                _doctorLicenseAndCertificationRepository.AddOrUpdate(doctorLicenseAndCertificationDTO);
            }
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<DoctorLicenseAndCertificationDTO>(doctorLicenseAndCertificationDTO);
        }
    }
}