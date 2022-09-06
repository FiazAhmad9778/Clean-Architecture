using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using iHakeem.Application.EMR.ExerciseHistory.Contracts;
using iHakeem.Database.AppDbContext;
using CurrentMed = iHakeem.Domain.Models.ExerciseHistory;
using iHakeem.Domain.EMR.ExerciseHistory.IDomainRepository;
using iHakeem.Infrastructure.Common.Exceptions;
using MediatR;
using Microsoft.Extensions.Localization;

namespace iHakeem.Application.EMR.ExerciseHistory.QueryHandlers.Detail
{
    public class ExerciseHistoryDetailHandler : IRequestHandler<GetExerciseHistoryRequestDTO, ExerciseHistoryResponseDTO>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IExerciseHistoryRepository _ExerciseHistoryRepository;

        public ExerciseHistoryDetailHandler(IExerciseHistoryRepository ExerciseHistoryRepository, ApplicationDbContext dbContext,
            IMapper mapper)
        {
            _ExerciseHistoryRepository = ExerciseHistoryRepository;
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<ExerciseHistoryResponseDTO> Handle(GetExerciseHistoryRequestDTO request, CancellationToken cancellationToken)
        {
            var user = await _ExerciseHistoryRepository.GetSingle(request.Id);
            return _mapper.Map<ExerciseHistoryResponseDTO>(user);
        }
    }
}
