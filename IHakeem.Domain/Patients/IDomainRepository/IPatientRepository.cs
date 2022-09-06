using iHakeem.Domain.Models;
using iHakeem.SharedKernal.Domain.IRepository;

namespace iHakeem.Domain.Patients.IDomainRepository
{
    public interface IPatientRepository
        : IBaseRepository<Patient>
    {
    }


}
