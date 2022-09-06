using AutoMapper;
using PatientFamily = iHakeem.Domain.Models.PulseOximeter;
using iHakeem.Domain.MyVitals.PulseOximeter.IDomainRepository;
using iHakeem.SharedKernal.Domain.IUnitOfWork;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.MyVitals.PulseOximeter.CommandHandlers.Delete
{
    public class PulseOximeterDeleteHandler : IRequestHandler<PulseOximeterDeleteRequestDTO, bool>
    {
        private readonly IPulseOximeterRepository _PulseOximeterRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PulseOximeterDeleteHandler(IPulseOximeterRepository PulseOximeterRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _PulseOximeterRepository = PulseOximeterRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(PulseOximeterDeleteRequestDTO request,
            CancellationToken cancellationToken)
        {
            var res = await _PulseOximeterRepository.GetSingle(x => x.Id == request.Id);
            var user = _mapper.Map<PatientFamily>(res);
            user.IsDeleted = true;
            _PulseOximeterRepository.Update(user);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
