
using System;
using iHakeem.Database.AppDbContext;
using iHakeem.Domain.EMR.SocialHistory.IDomainRepository;
using iHakeem.Domain.Models;
using iHakeem.Domain.Users.IDomainRepository;
using iHakeem.Infrastructure.EF.Repository;

namespace iHakeem.Infrastructure.EF.Repositories
{
    public class SocialHistoryRepository : BaseRepository<SocialHistory>, ISocialHistoryRepository
    {

        public SocialHistoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
