using System;
using iHakeem.Database.AppDbContext;
using iHakeem.Domain.EMR.RecreationalDrugsHistory.IDomainRepository;
using iHakeem.Domain.Models;
using iHakeem.Domain.Users.IDomainRepository;
using iHakeem.Infrastructure.EF.Repository;

namespace iHakeem.Infrastructure.EF.Repositories
{
    public class RecreationalDrugsHistoryRepository : BaseRepository<RecreationalDrugsHistory>, IRecreationalDrugsHistoryRepository
    {

        public RecreationalDrugsHistoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
