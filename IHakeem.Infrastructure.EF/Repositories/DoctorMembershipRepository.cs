using iHakeem.Database.AppDbContext;
using iHakeem.Domain.Doctors.Memberships.IDomainRepository;
using iHakeem.Domain.Models;
using iHakeem.Infrastructure.EF.Repository;

namespace iHakeem.Infrastructure.EF.Repositories
{
    public class DoctorMembershipRepository : BaseRepository<DoctorMembership>, IDoctorMembershipRepository
    {

        public DoctorMembershipRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

    }
}
