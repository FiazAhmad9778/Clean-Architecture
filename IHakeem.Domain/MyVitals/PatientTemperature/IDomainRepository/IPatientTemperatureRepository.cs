using Weight=iHakeem.Domain.Models.PatientTemperature;
using iHakeem.SharedKernal.Domain.IRepository;

namespace iHakeem.Domain.MyVitals.PatientTemperature.IDomainRepository
{
    public interface IPatientTemperatureRepository
        : IBaseRepository<Weight>
    {
    }


}
