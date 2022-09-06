using AutoMapper;
using iHakeem.Application.Doctors.AwardsAndRecognition.Contracts;
using iHakeem.Application.Doctors.DoctorAwardsAndRecognitions.CommadHandler.Create;
using iHakeem.Domain.Doctors.AwardsAndRecognitions.IDomainRepository;
using iHakeem.Domain.Models;
using iHakeem.SharedKernal.Domain.IUnitOfWork;
using MAP.Common.Extensions;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.Doctors.AwardsAndRecognition.CommadHandler.Create
{
    public class DoctorAwardsAndRecognitionRequestHandler : IRequestHandler<DoctorAwardsAndRecognitionCreateRequestDTO, DoctorAwardsAndRecognitionDTO>
    {
        private readonly IDoctorAwardsAndRecognitionRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DoctorAwardsAndRecognitionRequestHandler(IDoctorAwardsAndRecognitionRepository repository,
            IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<DoctorAwardsAndRecognitionDTO> Handle(DoctorAwardsAndRecognitionCreateRequestDTO request, CancellationToken cancellationToken)
        {

            var doctorAwardsAndRecognitionDTO = _mapper.Map<DoctorAwardsAndRecognition>(request);
            if (doctorAwardsAndRecognitionDTO != null)
            {
                _repository.AddOrUpdate(doctorAwardsAndRecognitionDTO);
            }
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<DoctorAwardsAndRecognitionDTO>(doctorAwardsAndRecognitionDTO);
        }
    }
}