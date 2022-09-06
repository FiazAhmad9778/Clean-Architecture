using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using iHakeem.Application.EMR.RecreationalDrugsHistory.Contracts;
using CurrentMed = iHakeem.Domain.Models.RecreationalDrugsHistory;
using iHakeem.Domain.EMR.RecreationalDrugsHistory.IDomainRepository;
using MediatR;
using iHakeem.SharedKernal.Domain.IUnitOfWork;

namespace iHakeem.Application.EMR.RecreationalDrugsHistory.CommandHandlers.Delete
{
    public class DeleteRecreationalDrugsHistoryHandler : IRequestHandler<DeleteRecreationalDrugsHistoryRequestDTO, bool>
    {
        private readonly IRecreationalDrugsHistoryRepository _RecreationalDrugsHistoryRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteRecreationalDrugsHistoryHandler(IRecreationalDrugsHistoryRepository RecreationalDrugsHistoryRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _RecreationalDrugsHistoryRepository = RecreationalDrugsHistoryRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(DeleteRecreationalDrugsHistoryRequestDTO request,
            CancellationToken cancellationToken)
        {
            var res = await _RecreationalDrugsHistoryRepository.GetSingle(x => x.Id == request.Id);
            CurrentMed user = _mapper.Map<CurrentMed>(res);
            user.IsDeleted = true;
            _RecreationalDrugsHistoryRepository.Update(user);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
