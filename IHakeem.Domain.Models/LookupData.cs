using iHakeem.SharedKernal.BaseDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace iHakeem.Domain.Models
{
    public class LookupData : EntityBase<int>
    {
        public int LookupId { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }

        public Lookup Lookup { get; set; }
    }
}
