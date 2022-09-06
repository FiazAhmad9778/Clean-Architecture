using System.Collections.Generic;
using iHakeem.SharedKernal.BaseDomain;

namespace iHakeem.Domain.Models
{
    public class Categories : AuditEntity<long>
    {
        public Categories()
        {
        }
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}
