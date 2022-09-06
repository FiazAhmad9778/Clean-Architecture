using iHakeem.SharedKernal.BaseDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace iHakeem.Domain.Models
{
    public class Lookup : EntityBase<int>
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public virtual ICollection<LookupData> LookupData { get; set; }
    }
}
