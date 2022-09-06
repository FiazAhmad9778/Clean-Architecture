using AutoMapper;
using iHakeem.Application.Doctors.DoctorServices.Contracts;
using iHakeem.Domain.Doctors.DoctorServices.IDomainRepository;
using iHakeem.Domain.Models;
using iHakeem.SharedKernal.Domain.IUnitOfWork;
using MAP.Common.Extensions;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.Doctors.DoctorServices.CommadHandler.Create
{
    public class DoctorServiceRequestHandler : IRequestHandler<DoctorServiceCreateRequestDTO, DoctorServiceDTO>
    {
        private readonly IDoctorServiceRepository _doctorServiceRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DoctorServiceRequestHandler(IDoctorServiceRepository doctorServiceRepository,
            IMapper mapper, IUnitOfWork unitOfWork)
        {
            _doctorServiceRepository = doctorServiceRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<DoctorServiceDTO> Handle(DoctorServiceCreateRequestDTO request, CancellationToken cancellationToken)
        {

            var doctorServiceDTO = _mapper.Map<DoctorService>(request);
            if (doctorServiceDTO != null)
            {
                _doctorServiceRepository.AddOrUpdate(doctorServiceDTO);
            }
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<DoctorServiceDTO>(doctorServiceDTO);
        }
    }
}