


using iHakeem.Application.Blogs.Categories.Contracts;
using MediatR;
using System.Collections.Generic;

namespace iHakeem.Application.Blogs.Categories.QueryHandlers.Detail
{
    public class GetAllCategoriesDetailRequestDTO : IRequest<List<CategoriesResponseDTO>>
    {
    }
}
