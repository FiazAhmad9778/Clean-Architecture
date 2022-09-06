using iHakeem.Domain.Models;
using iHakeem.SharedKernal.Domain.IRepository;

namespace iHakeem.Domain.EMR.EMRPatientHistory.IDomainRepository
{
    public interface IEMRPatientHistoryRepository
        : IBaseRepository<GetAllPatientHistory>
    {
    }


}
