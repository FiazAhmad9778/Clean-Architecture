using iHakeem.Database.AppDbContext;
using iHakeem.Domain.Doctors.References.IDomainRepository;
using iHakeem.Domain.Models;
using iHakeem.Infrastructure.EF.Repository;

namespace iHakeem.Infrastructure.EF.Repositories
{
    public class DoctorReferenceRepository : BaseRepository<DoctorReference>, IDoctorReferenceRepository
    {

        public DoctorReferenceRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

    }
}
