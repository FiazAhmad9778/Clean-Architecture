using FluentValidation;
using iHakeem.Application.EMR.PharmacyInformation.Contracts;
using MediatR;
using System;

namespace iHakeem.Application.EMR.PharmacyInformation.CommandHandlers.Edit
{
    public class EditPharmacyInformationRequestDTO : IRequest<PharmacyInformationResponseDTO>
    {
        public long Id { get; set; }
        public string PharmacyName { get; set; }
        public string PharmacyAddress { get; set; }
        public long? CountryId { get; set; }
        public long? StateId { get; set; }
        public long? CityId { get; set; }
        public string PhoneNumber { get; set; }
        public string Fax { get; set; }

        public class EditPharmacyInformationRequestDTOValidator : AbstractValidator<EditPharmacyInformationRequestDTO>
        {
            public EditPharmacyInformationRequestDTOValidator()
            {
                RuleFor(x => x.Id).NotEmpty();
                RuleFor(x => x.PharmacyName).NotEmpty();
            }
        }
    }

}
