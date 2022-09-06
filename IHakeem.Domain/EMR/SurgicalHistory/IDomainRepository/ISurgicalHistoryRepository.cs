using SurHistory=iHakeem.Domain.Models.SurgicalHistory;
using iHakeem.SharedKernal.Domain.IRepository;

namespace iHakeem.Domain.EMR.SurgicalHistory.IDomainRepository
{
    public interface ISurgicalHistoryRepository
        : IBaseRepository<SurHistory>
    {
    }


}
