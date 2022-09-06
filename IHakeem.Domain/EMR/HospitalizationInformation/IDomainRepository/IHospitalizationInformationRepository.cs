using Hospitalization=iHakeem.Domain.Models.HospitalizationInformation;
using iHakeem.SharedKernal.Domain.IRepository;

namespace iHakeem.Domain.EMR.HospitalizationInformation.IDomainRepository
{
    public interface IHospitalizationInformationRepository
        : IBaseRepository<Hospitalization>
    {
    }


}
