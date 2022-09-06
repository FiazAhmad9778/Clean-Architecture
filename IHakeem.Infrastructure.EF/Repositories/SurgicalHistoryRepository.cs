using System;
using iHakeem.Database.AppDbContext;
using iHakeem.Domain.EMR.SurgicalHistory.IDomainRepository;
using iHakeem.Domain.Models;
using iHakeem.Domain.Users.IDomainRepository;
using iHakeem.Infrastructure.EF.Repository;

namespace iHakeem.Infrastructure.EF.Repositories
{
    public class SurgicalHistoryRepository : BaseRepository<SurgicalHistory>, ISurgicalHistoryRepository
    {

        public SurgicalHistoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
