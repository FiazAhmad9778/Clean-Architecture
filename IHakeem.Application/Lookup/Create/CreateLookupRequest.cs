using iHakeem.Application.Lookup.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace iHakeem.Application.Lookup.Create
{
    public class CreateOrUpdateLookupRequestDTO : IRequest<LookupResponseDTO>
    {
        public int Id { get; set; }
        public int LookupId { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
    }
}
