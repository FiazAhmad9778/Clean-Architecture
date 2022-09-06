using AutoMapper;
using iHakeem.Domain.Doctors.DoctorServices.IDomainRepository;
using iHakeem.SharedKernal.Domain.IUnitOfWork;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.Doctors.Services.CommadHandler.Delete
{
    public class DoctorServiceDeleteHandler : IRequestHandler<DoctorServiceDeleteRequestDTO, bool>
    {
        private readonly IDoctorServiceRepository _doctorServiceRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DoctorServiceDeleteHandler(IDoctorServiceRepository doctorServiceRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _doctorServiceRepository = doctorServiceRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(DoctorServiceDeleteRequestDTO request,
            CancellationToken cancellationToken)
        {
            var res = await _doctorServiceRepository.GetSingle(x => x.Id == request.Id);
            res.IsDeleted = true;
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
