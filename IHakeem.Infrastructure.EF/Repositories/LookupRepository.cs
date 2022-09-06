using System;
using iHakeem.Database.AppDbContext;
using iHakeem.Domain.Lookups.IDomainRepository;
using iHakeem.Domain.Models;
using iHakeem.Infrastructure.EF.Repository;

namespace iHakeem.Infrastructure.EF.Repositories
{
    public class LookupRepository : BaseRepository<Lookup>, ILookupRepository
    {

        public LookupRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
