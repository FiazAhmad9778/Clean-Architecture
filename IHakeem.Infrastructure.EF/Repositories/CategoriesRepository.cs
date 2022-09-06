using System;
using iHakeem.Database.AppDbContext;
using iHakeem.Domain.Blogs.Categories.IDomainRepository;
using iHakeem.Domain.Models;
using iHakeem.Domain.Users.IDomainRepository;
using iHakeem.Infrastructure.EF.Repository;

namespace iHakeem.Infrastructure.EF.Repositories
{
    public class CategoriesRepository : BaseRepository<Categories>, ICategoriesRepository
    {

        public CategoriesRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
