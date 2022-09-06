
using System;
using iHakeem.Database.AppDbContext;
using iHakeem.Domain.EMR.PregnanciesHistory.IDomainRepository;
using iHakeem.Domain.Models;
using iHakeem.Domain.Users.IDomainRepository;
using iHakeem.Infrastructure.EF.Repository;

namespace iHakeem.Infrastructure.EF.Repositories
{
    public class PregnanciesHistoryRepository : BaseRepository<PregnanciesHistory>, IPregnanciesHistoryRepository
    {

        public PregnanciesHistoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
