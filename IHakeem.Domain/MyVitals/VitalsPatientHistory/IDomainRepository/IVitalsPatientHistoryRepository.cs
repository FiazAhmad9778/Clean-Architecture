using iHakeem.Domain.Models;
using iHakeem.SharedKernal.Domain.IRepository;

namespace iHakeem.Domain.EMR.VitalsPatientHistory.IDomainRepository
{
    public interface IVitalsPatientHistoryRepository
        : IBaseRepository<GetAllPatientVitalsHistory>
    {
    }


}
