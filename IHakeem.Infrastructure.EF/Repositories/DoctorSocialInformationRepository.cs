using iHakeem.Database.AppDbContext;
using iHakeem.Domain.Doctors.SocialInfo.IDomainRepository;
using iHakeem.Domain.Models;
using iHakeem.Infrastructure.EF.Repository;

namespace iHakeem.Infrastructure.EF.Repositories
{
    public class DoctorSocialInformationRepository : BaseRepository<DoctorSocialInfo>, IDoctorSocialInformationRepository
    {
        public DoctorSocialInformationRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
