using Weight=iHakeem.Domain.Models.PatientWeight;
using iHakeem.SharedKernal.Domain.IRepository;

namespace iHakeem.Domain.MyVitals.PatientWeight.IDomainRepository
{
    public interface IPatientWeightRepository
        : IBaseRepository<Weight>
    {
    }


}
