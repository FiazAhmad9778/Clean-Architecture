using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using iHakeem.Application.EMR.RecreationalDrugsHistory.Contracts;
using iHakeem.Database.AppDbContext;
using CurrentMed = iHakeem.Domain.Models.RecreationalDrugsHistory;
using iHakeem.Domain.EMR.RecreationalDrugsHistory.IDomainRepository;
using iHakeem.Infrastructure.Common.Exceptions;
using MediatR;
using Microsoft.Extensions.Localization;

namespace iHakeem.Application.EMR.RecreationalDrugsHistory.QueryHandlers.Detail
{
    public class RecreationalDrugsHistoryDetailHandler : IRequestHandler<GetRecreationalDrugsHistoryRequestDTO, RecreationalDrugsHistoryResponseDTO>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IRecreationalDrugsHistoryRepository _RecreationalDrugsHistoryRepository;

        public RecreationalDrugsHistoryDetailHandler(IRecreationalDrugsHistoryRepository RecreationalDrugsHistoryRepository, ApplicationDbContext dbContext,
            IMapper mapper)
        {
            _RecreationalDrugsHistoryRepository = RecreationalDrugsHistoryRepository;
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<RecreationalDrugsHistoryResponseDTO> Handle(GetRecreationalDrugsHistoryRequestDTO request, CancellationToken cancellationToken)
        {
            var user = await _RecreationalDrugsHistoryRepository.GetSingle(request.Id);
            return _mapper.Map<RecreationalDrugsHistoryResponseDTO>(user);
        }
    }
}
