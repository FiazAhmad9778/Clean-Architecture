using ExcHistory=iHakeem.Domain.Models.ExerciseHistory;
using iHakeem.SharedKernal.Domain.IRepository;

namespace iHakeem.Domain.EMR.ExerciseHistory.IDomainRepository
{
    public interface IExerciseHistoryRepository
        : IBaseRepository<ExcHistory>
    {
    }


}
