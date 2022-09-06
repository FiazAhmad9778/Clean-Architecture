using iHakeem.Database.AppDbContext;
using iHakeem.Domain.Doctors.WorkExperience.IDomainRepository;
using iHakeem.Domain.Models;
using iHakeem.Infrastructure.EF.Repository;

namespace iHakeem.Infrastructure.EF.Repositories
{
    public class DoctorWorkExperienceRepository : BaseRepository<DoctorWorkExperience>, IDoctorWorkExperienceRepository
    {

        public DoctorWorkExperienceRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

    }
}
