using System.Collections.Generic;
using iHakeem.SharedKernal.BaseDomain;

namespace iHakeem.Domain.Models
{
    public class Blogs : AuditEntity<long>
    {
        public Blogs()
        {
        }
        public long PostTitle { get; set; }
        public string Content { get; set; }
        public string BlogTags { get; set; }
        public string MetaTags { get; set; }
        public bool MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public string SelectImage { get; set; }
        public string ImageAlt { get; set; }
        public string Status { get; set; }
    }
}
