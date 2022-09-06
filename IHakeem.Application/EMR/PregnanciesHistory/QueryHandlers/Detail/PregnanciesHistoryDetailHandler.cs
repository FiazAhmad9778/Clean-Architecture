using AutoMapper;
using iHakeem.Application.EMR.PregnanciesHistory.Contracts;
using iHakeem.Database.AppDbContext;
using iHakeem.Domain.EMR.PregnanciesHistory.IDomainRepository;
using iHakeem.Infrastructure.Security.Abstractions;
using iHakeem.SharedKernal;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.EMR.PregnanciesHistory.QueryHandlers.Detail
{
    public class PregnanciesHistoryDetailHandler : IRequestHandler<GetPregnanciesHistoryRequestDTO, PregnanciesHistoryResponseDTO>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly CommonMethods _commonMethods;
        private readonly IPregnanciesHistoryRepository _PregnanciesHistoryRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PregnanciesHistoryDetailHandler(IPregnanciesHistoryRepository PregnanciesHistoryRepository, ApplicationDbContext dbContext,
            IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _PregnanciesHistoryRepository = PregnanciesHistoryRepository;
            _dbContext = dbContext;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _commonMethods = new CommonMethods(_httpContextAccessor);
        }
        public async Task<PregnanciesHistoryResponseDTO> Handle(GetPregnanciesHistoryRequestDTO request, CancellationToken cancellationToken)
        {
            var user = await _PregnanciesHistoryRepository.GetSingle(request.Id);
            var patientId = _commonMethods.GetClaim(ClaimConstant.ReferenceId);
            return _mapper.Map<PregnanciesHistoryResponseDTO>(user);
        }
    }
}
