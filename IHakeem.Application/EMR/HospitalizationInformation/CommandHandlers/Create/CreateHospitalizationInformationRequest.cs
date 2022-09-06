using FluentValidation;
using iHakeem.Application.EMR.HospitalizationInformation.Contracts;
using MediatR;
using System;

namespace iHakeem.Application.EMR.HospitalizationInformation.CommandHandlers.Create
{
    public class CreateHospitalizationInformationRequestDTO : IRequest<HospitalizationInformationResponseDTO>
    {
        public string HospitalName { get; set; }
        public string HospitaliazationYear { get; set; }
        public string PhoneNumber { get; set; }
        public long? ReasonId { get; set; }
        public string location { get; set; }
        public string HospitalizaitonNotes { get; set; }


        public class CreateHospitalizationInformationRequestDTOValidator : AbstractValidator<CreateHospitalizationInformationRequestDTO>
        {
            public CreateHospitalizationInformationRequestDTOValidator()
            {
                RuleFor(x => x.HospitalName).NotEmpty();
            }
        }
    }

}
