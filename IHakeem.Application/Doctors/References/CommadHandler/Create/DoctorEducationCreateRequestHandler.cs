using AutoMapper;
using iHakeem.Application.Doctors.Reference.CommadHandler.Create;
using iHakeem.Application.Doctors.References.Contracts;
using iHakeem.Domain.Doctors.References.IDomainRepository;
using iHakeem.Domain.Models;
using iHakeem.SharedKernal.Domain.IUnitOfWork;
using MAP.Common.Extensions;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.Doctors.References.CommadHandler.Create
{
    public class DoctorReferenceRequestHandler : IRequestHandler<DoctorReferenceCreateRequestDTO, DoctorReferenceDTO>
    {
        private readonly IDoctorReferenceRepository _doctorReferenceRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DoctorReferenceRequestHandler(IDoctorReferenceRepository doctorReferenceRepository,
            IMapper mapper, IUnitOfWork unitOfWork)
        {
            _doctorReferenceRepository = doctorReferenceRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<DoctorReferenceDTO> Handle(DoctorReferenceCreateRequestDTO request, CancellationToken cancellationToken)
        {

            var doctorReferenceDTO = _mapper.Map<DoctorReference>(request);
            if (doctorReferenceDTO != null)
            {
                _doctorReferenceRepository.AddOrUpdate(doctorReferenceDTO);
            }
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<DoctorReferenceDTO>(doctorReferenceDTO);
        }
    }
}