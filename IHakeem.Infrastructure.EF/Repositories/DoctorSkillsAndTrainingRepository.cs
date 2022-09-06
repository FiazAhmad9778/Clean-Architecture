using iHakeem.Database.AppDbContext;
using iHakeem.Domain.Doctors.TrainingAndSkills.IDomainRepository;
using iHakeem.Domain.Models;
using iHakeem.Infrastructure.EF.Repository;

namespace iHakeem.Infrastructure.EF.Repositories
{
    public class DoctorSkillsAndTrainingRepository : BaseRepository<DoctorSkillsAndTraining>, IDoctorSkillsAndTrainingRepository
    {

        public DoctorSkillsAndTrainingRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

    }
}
