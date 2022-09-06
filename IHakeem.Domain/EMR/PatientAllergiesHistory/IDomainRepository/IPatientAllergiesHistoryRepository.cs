using SurHistory=iHakeem.Domain.Models.PatientAllergiesHistory;
using iHakeem.SharedKernal.Domain.IRepository;

namespace iHakeem.Domain.EMR.PatientAllergiesHistory.IDomainRepository
{
    public interface IPatientAllergiesHistoryRepository
        : IBaseRepository<SurHistory>
    {
    }


}
