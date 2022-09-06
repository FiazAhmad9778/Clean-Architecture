using ExcHistory=iHakeem.Domain.Models.PatientBloodPressure;
using iHakeem.SharedKernal.Domain.IRepository;

namespace iHakeem.Domain.MyVitals.PatientBloodPressure.IDomainRepository
{
    public interface IPatientBloodPressureRepository
        : IBaseRepository<ExcHistory>
    {
    }


}
