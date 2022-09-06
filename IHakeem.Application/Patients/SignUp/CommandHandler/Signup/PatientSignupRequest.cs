using FluentValidation;
using iHakeem.Application.EMR.CurrentMedication.Contracts;
using iHakeem.Application.Patients.Contracts;
using iHakeem.Application.Users.Common;
using MediatR;

namespace iHakeem.Application.Patients.CommandHandler.Signup
{
    public class PatientSignupRequestDTO : UserSignupRequestDTO, IRequest<PatientSignupResponseDTO>
    {
        public class PatientSignupRequestDTOValidator : AbstractValidator<PatientSignupRequestDTO>
        {
            public PatientSignupRequestDTOValidator()
            {
                RuleFor(x => x.FirstName).NotEmpty();
                RuleFor(x => x.LastName).NotEmpty();
                RuleFor(x => x.PhoneNumber).NotEmpty();
                RuleFor(x => x.Email).NotEmpty();
                RuleFor(x => x.UserName).NotEmpty();
                RuleFor(x => x.Password).NotEmpty();
            }
        }
    }

}
