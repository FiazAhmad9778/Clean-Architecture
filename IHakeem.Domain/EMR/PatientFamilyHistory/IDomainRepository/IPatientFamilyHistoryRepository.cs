using CurrentMed=iHakeem.Domain.Models.PatientFamilyHistory;
using iHakeem.SharedKernal.Domain.IRepository;

namespace iHakeem.Domain.EMR.PatientFamilyHistory.IDomainRepository
{
    public interface IPatientFamilyHistoryRepository
        : IBaseRepository<CurrentMed>
    {
    }


}
