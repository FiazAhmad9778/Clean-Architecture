using iHakeem.Database.AppDbContext;
using iHakeem.Domain.Doctors.AwardsAndRecognitions.IDomainRepository;
using iHakeem.Domain.Models;
using iHakeem.Infrastructure.EF.Repository;

namespace iHakeem.Infrastructure.EF.Repositories
{
    public class DoctorAwardsAndRecognitionRepository : BaseRepository<DoctorAwardsAndRecognition>, IDoctorAwardsAndRecognitionRepository
    {

        public DoctorAwardsAndRecognitionRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

    }
}
