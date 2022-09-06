using AutoMapper;
using iHakeem.Domain.Doctors.References.IDomainRepository;
using iHakeem.SharedKernal.Domain.IUnitOfWork;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.Doctors.References.CommadHandler.Delete
{
    public class DoctorReferenceDeleteHandler : IRequestHandler<DoctorReferenceDeleteRequestDTO, bool>
    {
        private readonly IDoctorReferenceRepository _doctorReferenceRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DoctorReferenceDeleteHandler(IDoctorReferenceRepository doctorReferenceRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _doctorReferenceRepository = doctorReferenceRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(DoctorReferenceDeleteRequestDTO request,
            CancellationToken cancellationToken)
        {
            var res = await _doctorReferenceRepository.GetSingle(x => x.Id == request.Id);
            res.IsDeleted = true;
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
