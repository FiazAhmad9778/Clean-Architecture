using ExcHistory=iHakeem.Domain.Models.PatientHobbiesHistory;
using iHakeem.SharedKernal.Domain.IRepository;

namespace iHakeem.Domain.EMR.PatientHobbiesHistory.IDomainRepository
{
    public interface IPatientHobbiesHistoryRepository
        : IBaseRepository<ExcHistory>
    {
    }


}
