using System;
using System.Collections.Generic;
using System.Text;

namespace iHakeem.Application.Lookup.Contracts
{
    public class LookupResponseDTO
    {
        public int id { get; set; }
        public int LookupId { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
    }
}
