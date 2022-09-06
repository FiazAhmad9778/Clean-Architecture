using iHakeem.SharedKernal.BaseDomain;
using System;

namespace iHakeem.Domain.Models
{
    public class File : EntityBase<long>
    {
        public int Type { get; set; }

        public string Reference { get; set; }

        public string ContentType { get; set; }

        public string OriginalName { get; set; }

        public int SizeBytes { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
