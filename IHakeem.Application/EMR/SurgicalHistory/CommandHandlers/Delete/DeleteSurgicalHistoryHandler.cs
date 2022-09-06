using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using iHakeem.Application.EMR.SurgicalHistory.Contracts;
using CurrentMed = iHakeem.Domain.Models.SurgicalHistory;
using iHakeem.Domain.EMR.SurgicalHistory.IDomainRepository;
using MediatR;
using iHakeem.SharedKernal.Domain.IUnitOfWork;

namespace iHakeem.Application.EMR.SurgicalHistory.CommandHandlers.Delete
{
    public class DeleteSurgicalHistoryHandler : IRequestHandler<DeleteSurgicalHistoryRequestDTO, bool>
    {
        private readonly ISurgicalHistoryRepository _SurgicalHistoryRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteSurgicalHistoryHandler(ISurgicalHistoryRepository SurgicalHistoryRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _SurgicalHistoryRepository = SurgicalHistoryRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(DeleteSurgicalHistoryRequestDTO request,
            CancellationToken cancellationToken)
        {
            var res = await _SurgicalHistoryRepository.GetSingle(x => x.Id == request.Id);
            CurrentMed user = _mapper.Map<CurrentMed>(res);
            user.IsDeleted = true;
             _SurgicalHistoryRepository.Update(user);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
