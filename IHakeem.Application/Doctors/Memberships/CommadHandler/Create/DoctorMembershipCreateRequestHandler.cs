using AutoMapper;
using iHakeem.Application.Doctors.Memberships.Contracts;
using iHakeem.Domain.Doctors.Memberships.IDomainRepository;
using iHakeem.Domain.Models;
using iHakeem.SharedKernal.Domain.IUnitOfWork;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.Doctors.Memberships.CommadHandler.Create
{
    public class DoctorMembershipRequestHandler : IRequestHandler<DoctorMembershipCreateRequestDTO, DoctorMembershipDTO>
    {
        private readonly IDoctorMembershipRepository _doctorMembershipRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DoctorMembershipRequestHandler(IDoctorMembershipRepository doctorMembershipRepository,
            IMapper mapper, IUnitOfWork unitOfWork)
        {
            _doctorMembershipRepository = doctorMembershipRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<DoctorMembershipDTO> Handle(DoctorMembershipCreateRequestDTO request, CancellationToken cancellationToken)
        {

            var doctorMembershipDTO = _mapper.Map<DoctorMembership>(request);
            if (doctorMembershipDTO != null)
            {
                _doctorMembershipRepository.AddOrUpdate(doctorMembershipDTO);
            }
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<DoctorMembershipDTO>(doctorMembershipDTO);
        }
    }
}