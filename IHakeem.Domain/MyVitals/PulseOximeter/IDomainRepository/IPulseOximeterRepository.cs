using Oximeter=iHakeem.Domain.Models.PulseOximeter;
using iHakeem.SharedKernal.Domain.IRepository;

namespace iHakeem.Domain.MyVitals.PulseOximeter.IDomainRepository
{
    public interface IPulseOximeterRepository
        : IBaseRepository<Oximeter>
    {
    }


}
