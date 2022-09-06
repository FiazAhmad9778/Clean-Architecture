using FluentValidation;
using iHakeem.Application.EMR.CurrentMedication.Contracts;
using iHakeem.Application.Doctors.Contracts;
using iHakeem.Application.Users.Common;
using MediatR;

namespace iHakeem.Application.Doctors.CommandHandler.Signup
{
    public class DoctorSignupRequestDTO : UserSignupRequestDTO, IRequest<DoctorSignupResponseDTO>
    {
        public class DoctorSignupRequestDTOValidator : AbstractValidator<DoctorSignupRequestDTO>
        {
            public DoctorSignupRequestDTOValidator()
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
