using AutoMapper;
using PatientFamily = iHakeem.Domain.Models.PregnanciesHistory;
using iHakeem.Domain.EMR.PregnanciesHistory.IDomainRepository;
using iHakeem.SharedKernal.Domain.IUnitOfWork;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.EMR.PregnanciesHistory.CommandHandlers.Delete
{
    public class PregnanciesHistoryDeleteHandler : IRequestHandler<PregnanciesHistoryDeleteRequestDTO, bool>
    {
        private readonly IPregnanciesHistoryRepository _PregnanciesHistoryRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PregnanciesHistoryDeleteHandler(IPregnanciesHistoryRepository PregnanciesHistoryRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _PregnanciesHistoryRepository = PregnanciesHistoryRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(PregnanciesHistoryDeleteRequestDTO request,
            CancellationToken cancellationToken)
        {
            var res = await _PregnanciesHistoryRepository.GetSingle(x => x.Id == request.Id);
            var user = _mapper.Map<PatientFamily>(res);
            user.IsDeleted = true;
            _PregnanciesHistoryRepository.Update(user);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
