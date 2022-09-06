using FluentValidation;
using iHakeem.Application.EMR.HospitalizationInformation.Contracts;
using MediatR;
using System;

namespace iHakeem.Application.EMR.HospitalizationInformation.CommandHandlers.Edit
{
    public class EditHospitalizationInformationRequestDTO : IRequest<HospitalizationInformationResponseDTO>
    {
        public long Id { get; set; }
        public string HospitalName { get; set; }
        public string HospitaliazationYear { get; set; }
        public string PhoneNumber { get; set; }
        public long? ReasonId { get; set; }
        public string location { get; set; }
        public string HospitalizaitonNotes { get; set; }

        public class EditHospitalizationInformationRequestDTOValidator : AbstractValidator<EditHospitalizationInformationRequestDTO>
        {
            public EditHospitalizationInformationRequestDTOValidator()
            {
                RuleFor(x => x.Id).NotEmpty();
                RuleFor(x => x.HospitalName).NotEmpty();
            }
        }
    }

}
