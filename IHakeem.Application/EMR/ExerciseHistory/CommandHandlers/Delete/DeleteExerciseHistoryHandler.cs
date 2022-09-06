using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using iHakeem.Application.EMR.ExerciseHistory.Contracts;
using CurrentMed = iHakeem.Domain.Models.ExerciseHistory;
using iHakeem.Domain.EMR.ExerciseHistory.IDomainRepository;
using MediatR;
using iHakeem.SharedKernal.Domain.IUnitOfWork;

namespace iHakeem.Application.EMR.ExerciseHistory.CommandHandlers.Delete
{
    public class DeleteExerciseHistoryHandler : IRequestHandler<DeleteExerciseHistoryRequestDTO, bool>
    {
        private readonly IExerciseHistoryRepository _ExerciseHistoryRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteExerciseHistoryHandler(IExerciseHistoryRepository ExerciseHistoryRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _ExerciseHistoryRepository = ExerciseHistoryRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(DeleteExerciseHistoryRequestDTO request,
            CancellationToken cancellationToken)
        {
            var res = await _ExerciseHistoryRepository.GetSingle(x => x.Id == request.Id);
            CurrentMed user = _mapper.Map<CurrentMed>(res);
            user.IsDeleted = true;
            _ExerciseHistoryRepository.Update(user);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
