using CurrentMed=iHakeem.Domain.Models.PregnanciesHistory;
using iHakeem.SharedKernal.Domain.IRepository;

namespace iHakeem.Domain.EMR.PregnanciesHistory.IDomainRepository
{
    public interface IPregnanciesHistoryRepository
        : IBaseRepository<CurrentMed>
    {
    }


}
