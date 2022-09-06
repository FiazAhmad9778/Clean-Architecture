using SocialHistoryPatient=iHakeem.Domain.Models.SocialHistory;
using iHakeem.SharedKernal.Domain.IRepository;

namespace iHakeem.Domain.EMR.SocialHistory.IDomainRepository
{
    public interface ISocialHistoryRepository
        : IBaseRepository<SocialHistoryPatient>
    {
    }


}
