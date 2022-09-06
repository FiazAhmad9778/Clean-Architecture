using AutoMapper;
using iHakeem.Application.Doctors.Education.Contracts;
using iHakeem.Application.Patients.PersonalInfo.Contracts;
using iHakeem.Domain.Doctors.Education;
using iHakeem.Domain.Models;
using iHakeem.Domain.Patients.PatientSocialInfo.IDomainRepository;
using iHakeem.SharedKernal.Domain.IUnitOfWork;
using MAP.Common.Extensions;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.Doctors.Education.CommadHandler.Create
{
    public class DoctorEducationRequestHandler : IRequestHandler<DoctorEducationCreateRequestDTO, DoctorEducationDTO>
    {
        private readonly IDoctorEducationRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DoctorEducationRequestHandler(IDoctorEducationRepository repository,
            IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<DoctorEducationDTO> Handle(DoctorEducationCreateRequestDTO request, CancellationToken cancellationToken)
        {

            var doctorEducation = _mapper.Map<DoctorEducation>(request);
            if (doctorEducation != null)
            {
                _repository.AddOrUpdate(doctorEducation);
            }
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<DoctorEducationDTO>(doctorEducation);
        }
    }
}