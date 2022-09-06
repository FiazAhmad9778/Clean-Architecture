using PatientHistory=iHakeem.Domain.Models.MyPhysicians;
using iHakeem.SharedKernal.Domain.IRepository;

namespace iHakeem.Domain.EMR.MyPhysicians.IDomainRepository
{
    public interface IMyPhysiciansRepository
        : IBaseRepository<PatientHistory>
    {
    }


}
