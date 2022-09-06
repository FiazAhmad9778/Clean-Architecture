using AutoMapper;
using iHakeem.Application.Doctors.PersonalInfo.Contracts;
using iHakeem.Domain.Doctors.IDomainRepository;
using iHakeem.Infrastructure.Common.Exceptions;
using iHakeem.SharedKernal.Domain.IUnitOfWork;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.Doctors.PersonalInfo.CommadHandler.Update
{
    public class DoctorPersonalInfoUpdateRequestHandler : IRequestHandler<DoctorPersonalInfoUpdateRequestDTO, DoctorPersonalInfoResponseDTO>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDoctorRepository _doctorRepository;

        public DoctorPersonalInfoUpdateRequestHandler(IDoctorRepository doctorRepository,
            IMapper mapper, IUnitOfWork unitOfWork)
        {
            _doctorRepository = doctorRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<DoctorPersonalInfoResponseDTO> Handle(DoctorPersonalInfoUpdateRequestDTO request, CancellationToken cancellationToken)
        {
            var existingDoctor = await _doctorRepository.GetSingle(x => x.Id == request.Id,
                x => x.MaritialStatus
               );
            if (existingDoctor == null) throw new CodedException(ErrorCode.InvalidDoctorId);

            _mapper.Map(request, existingDoctor);
            var respoonse = _doctorRepository.Update(existingDoctor);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<DoctorPersonalInfoResponseDTO>(respoonse);

        }
    }
}