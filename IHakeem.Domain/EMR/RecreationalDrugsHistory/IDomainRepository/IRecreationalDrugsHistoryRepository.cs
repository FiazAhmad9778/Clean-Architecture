using RecreationalDrugHistory = iHakeem.Domain.Models.RecreationalDrugsHistory;
using iHakeem.SharedKernal.Domain.IRepository;

namespace iHakeem.Domain.EMR.RecreationalDrugsHistory.IDomainRepository
{
    public interface IRecreationalDrugsHistoryRepository
        : IBaseRepository<RecreationalDrugHistory>
    {
    }


}
