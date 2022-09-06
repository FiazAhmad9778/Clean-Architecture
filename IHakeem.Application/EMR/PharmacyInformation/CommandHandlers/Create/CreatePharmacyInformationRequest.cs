using FluentValidation;
using iHakeem.Application.EMR.PharmacyInformation.Contracts;
using MediatR;
using System;

namespace iHakeem.Application.EMR.PharmacyInformation.CommandHandlers.Create
{
    public class CreatePharmacyInformationRequestDTO : IRequest<PharmacyInformationResponseDTO>
    {
        public string PharmacyName { get; set; }
        public string PharmacyAddress { get; set; }
        public long? CountryId { get; set; }
        public long? StateId { get; set; }
        public long? CityId { get; set; }
        public string PhoneNumber { get; set; }
        public string Fax { get; set; }


        public class CreatePharmacyInformationRequestDTOValidator : AbstractValidator<CreatePharmacyInformationRequestDTO>
        {
            public CreatePharmacyInformationRequestDTOValidator()
            {
                RuleFor(x => x.PharmacyName).NotEmpty();
            }
        }
    }

}
