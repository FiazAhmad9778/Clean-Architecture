using AutoMapper;
using iHakeem.Domain.EMR.SocialHistory.IDomainRepository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using CurrentMed = iHakeem.Domain.Models.SocialHistory;
using iHakeem.SharedKernal.Domain.IUnitOfWork;

namespace iHakeem.Application.EMR.SocialHistory.CommandHandlers.Delete
{
    public class DeleteSocialHistoryHandler : IRequestHandler<DeleteSocialHistoryRequestDTO, bool>
    {
        private readonly ISocialHistoryRepository _SocialHistoryRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteSocialHistoryHandler(ISocialHistoryRepository SocialHistoryRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _SocialHistoryRepository = SocialHistoryRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(DeleteSocialHistoryRequestDTO request,
            CancellationToken cancellationToken)
        {
            var res = await _SocialHistoryRepository.GetSingle(x => x.Id == request.Id);
            CurrentMed user = _mapper.Map<CurrentMed>(res);
            user.IsDeleted = true;
             _SocialHistoryRepository.Update(user);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
