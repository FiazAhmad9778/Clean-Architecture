
using System;
using iHakeem.Database.AppDbContext;
using iHakeem.Domain.EMR.DetailPregnancies.IDomainRepository;
using iHakeem.Domain.Models;
using iHakeem.Domain.Users.IDomainRepository;
using iHakeem.Infrastructure.EF.Repository;

namespace iHakeem.Infrastructure.EF.Repositories
{
    public class DetailPregnanciesRepository : BaseRepository<DetailPregnancies>, IDetailPregnanciesRepository
    {

        public DetailPregnanciesRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
