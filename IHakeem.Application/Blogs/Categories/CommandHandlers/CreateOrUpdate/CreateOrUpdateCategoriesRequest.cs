using iHakeem.Application.Blogs.Categories.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace iHakeem.Application.Blogs.Categories.CommandHandlers.CreateOrUpdate
{
    public class CreateOrUpdateCategoriesRequestDTO : IRequest<CategoriesResponseDTO>
    {
        public long Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}
