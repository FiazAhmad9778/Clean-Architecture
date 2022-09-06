using AutoMapper;
using iHakeem.Application.Doctors.WorkExperience.Contracts;
using iHakeem.Domain.Doctors.WorkExperience.IDomainRepository;
using iHakeem.Domain.Models;
using iHakeem.SharedKernal.Domain.IUnitOfWork;
using MAP.Common.Extensions;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.Doctors.WorkExperience.CommadHandler.Create
{
    public class DoctorWorkExperienceRequestHandler : IRequestHandler<DoctorWorkExperienceCreateRequestDTO, DoctorWorkExperienceDTO>
    {
        private readonly IDoctorWorkExperienceRepository _doctorWorkExperienceRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DoctorWorkExperienceRequestHandler(IDoctorWorkExperienceRepository doctorWorkExperienceRepository,
            IMapper mapper, IUnitOfWork unitOfWork)
        {
            _doctorWorkExperienceRepository = doctorWorkExperienceRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<DoctorWorkExperienceDTO> Handle(DoctorWorkExperienceCreateRequestDTO request, CancellationToken cancellationToken)
        {

            var doctorWorkExperienceDTO = _mapper.Map<DoctorWorkExperience>(request);
            if (doctorWorkExperienceDTO != null)
            {
                _doctorWorkExperienceRepository.AddOrUpdate(doctorWorkExperienceDTO);
            }
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<DoctorWorkExperienceDTO>(doctorWorkExperienceDTO);
        }
    }
}