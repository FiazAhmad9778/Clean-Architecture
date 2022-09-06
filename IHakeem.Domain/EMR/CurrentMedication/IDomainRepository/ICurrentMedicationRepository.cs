using CurrentMed=iHakeem.Domain.Models.CurrentMedication;
using iHakeem.SharedKernal.Domain.IRepository;

namespace iHakeem.Domain.EMR.CurrentMedication.IDomainRepository
{
    public interface ICurrentMedicationRepository
        : IBaseRepository<CurrentMed>
    {
    }


}
