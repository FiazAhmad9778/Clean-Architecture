using AutoMapper;
using iHakeem.Application.Doctors.SkillsAndtraining.Contracts;
using iHakeem.Domain.Doctors.TrainingAndSkills.IDomainRepository;
using iHakeem.Domain.Models;
using iHakeem.SharedKernal.Domain.IUnitOfWork;
using MAP.Common.Extensions;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.Doctors.SkillsAndtraining.CommadHandler.Create
{
    public class DoctorSkillsAndTrainingRequestHandler : IRequestHandler<DoctorSkillsAndTrainingCreateRequestDTO, DoctorSkillsAndTrainingDTO>
    {
        private readonly IDoctorSkillsAndTrainingRepository _doctorSkillsAndTrainingRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DoctorSkillsAndTrainingRequestHandler(IDoctorSkillsAndTrainingRepository doctorSkillsAndTrainingRepository,
            IMapper mapper, IUnitOfWork unitOfWork)
        {
            _doctorSkillsAndTrainingRepository = doctorSkillsAndTrainingRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<DoctorSkillsAndTrainingDTO> Handle(DoctorSkillsAndTrainingCreateRequestDTO request, CancellationToken cancellationToken)
        {

            var doctorSkillsAndTrainingDTO = _mapper.Map<DoctorSkillsAndTraining>(request);
            if (doctorSkillsAndTrainingDTO != null)
            {
                _doctorSkillsAndTrainingRepository.AddOrUpdate(doctorSkillsAndTrainingDTO);
            }
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<DoctorSkillsAndTrainingDTO>(doctorSkillsAndTrainingDTO);
        }
    }
}