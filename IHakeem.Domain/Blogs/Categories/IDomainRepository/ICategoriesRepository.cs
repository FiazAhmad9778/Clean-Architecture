using Category = iHakeem.Domain.Models.Categories;
using iHakeem.SharedKernal.Domain.IRepository;

namespace iHakeem.Domain.Blogs.Categories.IDomainRepository
{
    public interface ICategoriesRepository
        : IBaseRepository<Category>
    {
    }


}
