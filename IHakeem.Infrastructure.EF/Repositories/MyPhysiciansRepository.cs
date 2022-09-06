using System;
using iHakeem.Database.AppDbContext;
using iHakeem.Domain.EMR.MyPhysicians.IDomainRepository;
using iHakeem.Domain.Models;
using iHakeem.Domain.Users.IDomainRepository;
using iHakeem.Infrastructure.EF.Repository;

namespace iHakeem.Infrastructure.EF.Repositories
{
    public class MyPhysiciansRepository : BaseRepository<MyPhysicians>, IMyPhysiciansRepository
    {

        public MyPhysiciansRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
