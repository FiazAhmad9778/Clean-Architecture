using AutoMapper;
using iHakeem.Domain.Doctors.Memberships.IDomainRepository;
using iHakeem.SharedKernal.Domain.IUnitOfWork;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.Doctors.Memberships.CommadHandler.Delete
{
    public class DoctorMembershipDeleteHandler : IRequestHandler<DoctorMembershipDeleteRequestDTO, bool>
    {
        private readonly IDoctorMembershipRepository _doctorMembershipRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DoctorMembershipDeleteHandler(IDoctorMembershipRepository doctorMembershipRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _doctorMembershipRepository = doctorMembershipRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(DoctorMembershipDeleteRequestDTO request,
            CancellationToken cancellationToken)
        {
            var res = await _doctorMembershipRepository.GetSingle(x => x.Id == request.Id);
            res.IsDeleted = true;
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
