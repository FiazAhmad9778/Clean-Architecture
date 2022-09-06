using iHakeem.Application.Blogs.Categories.Contracts;
using MediatR;

namespace iHakeem.Application.Blogs.Categories.QueryHandlers.Detail
{
    public class GetCategoriesRequestDTO : IRequest<CategoriesResponseDTO>
    {
        public long Id { get; set; }
    }
}
