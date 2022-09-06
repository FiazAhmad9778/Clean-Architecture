using Pharmacy=iHakeem.Domain.Models.PharmacyInformation;
using iHakeem.SharedKernal.Domain.IRepository;

namespace iHakeem.Domain.EMR.PharmacyInformation.IDomainRepository
{
    public interface IPharmacyInformationRepository
        : IBaseRepository<Pharmacy>
    {
    }


}
