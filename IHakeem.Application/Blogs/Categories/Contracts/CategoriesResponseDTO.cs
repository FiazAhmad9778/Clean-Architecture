using iHakeem.SharedKernal.BaseDomain;
using System;

namespace iHakeem.Application.Blogs.Categories.Contracts
{
    public class CategoriesResponseDTO : AuditEntity<long>
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}
