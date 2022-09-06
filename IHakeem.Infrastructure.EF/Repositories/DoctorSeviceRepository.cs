using iHakeem.Database.AppDbContext;
using iHakeem.Domain.Doctors.DoctorServices.IDomainRepository;
using iHakeem.Domain.Models;
using iHakeem.Infrastructure.EF.Repository;

namespace iHakeem.Infrastructure.EF.Repositories
{
    public class DoctorServiceRepository : BaseRepository<DoctorService>, IDoctorServiceRepository
    {

        public DoctorServiceRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

    }
}
