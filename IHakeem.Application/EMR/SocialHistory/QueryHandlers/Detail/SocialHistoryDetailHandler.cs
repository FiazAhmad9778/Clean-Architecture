using AutoMapper;
using iHakeem.Application.EMR.SocialHistory.Contracts;
using iHakeem.Database.AppDbContext;
using iHakeem.Domain.EMR.SocialHistory.IDomainRepository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.EMR.SocialHistory.QueryHandlers.Detail
{
    public class SocialHistoryDetailHandler : IRequestHandler<GetSocialHistoryRequestDTO, SocialHistoryResponseDTO>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ISocialHistoryRepository _SocialHistoryRepository;

        public SocialHistoryDetailHandler(ISocialHistoryRepository SocialHistoryRepository, ApplicationDbContext dbContext,
            IMapper mapper)
        {
            _SocialHistoryRepository = SocialHistoryRepository;
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<SocialHistoryResponseDTO> Handle(GetSocialHistoryRequestDTO request, CancellationToken cancellationToken)
        {
            var user = await _SocialHistoryRepository.GetSingle(request.Id);
            return _mapper.Map<SocialHistoryResponseDTO>(user);
        }
    }
}
