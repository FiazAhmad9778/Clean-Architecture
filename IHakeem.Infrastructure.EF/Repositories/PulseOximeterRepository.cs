using System;
using iHakeem.Database.AppDbContext;
using iHakeem.Domain.MyVitals.PulseOximeter.IDomainRepository;
using iHakeem.Domain.Models;
using iHakeem.Domain.Users.IDomainRepository;
using iHakeem.Infrastructure.EF.Repository;

namespace iHakeem.Infrastructure.EF.Repositories
{
    public class PulseOximeterRepository : BaseRepository<PulseOximeter>, IPulseOximeterRepository
    {

        public PulseOximeterRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
