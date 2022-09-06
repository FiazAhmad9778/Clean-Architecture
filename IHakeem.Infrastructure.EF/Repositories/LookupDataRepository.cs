using iHakeem.Database.AppDbContext;
using iHakeem.Domain.Lookups.IDomainRepository;
using iHakeem.Domain.Models;
using iHakeem.Infrastructure.EF.Repository;

namespace iHakeem.Infrastructure.EF.Repositories
{
    public class LookupDataRepository : BaseRepository<LookupData>, ILookupDataRepository
    {

        public LookupDataRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
