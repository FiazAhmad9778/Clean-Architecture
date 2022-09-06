using System;
using iHakeem.Database.AppDbContext;
using iHakeem.Domain.Models;
using iHakeem.Domain.Users.IDomainRepository;
using iHakeem.Infrastructure.EF.Repository;

namespace iHakeem.Infrastructure.EF.Repositories
{
    public class UserRepository : BaseRepository<ApplicationUser>, IUserRepository
    {

        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
