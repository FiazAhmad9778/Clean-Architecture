using FluentValidation;
using iHakeem.Application.Lookup.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace iHakeem.Application.Lookup.QueryHandlers
{
    public class GetLookupByTypeRequestDTO : IRequest<List<LookupResponseDTO>>
    {
        public string LookupName { get; set; }

        public class GetLookupByTypeRequestDTOValidator : AbstractValidator<GetLookupByTypeRequestDTO>
        {
            public GetLookupByTypeRequestDTOValidator()
            {
                RuleFor(x => x.LookupName).NotEmpty();
            }
        }
    }
}
