using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace iHakeem.Application.Users.ChangePassword
{
    public class ChangePasswordRequestDTO : IRequest<Unit>
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }

        public class ChangePasswordRequestDTOValidator : AbstractValidator<ChangePasswordRequestDTO>
        {
            public ChangePasswordRequestDTOValidator()
            {
                RuleFor(x => x.OldPassword).NotEmpty();
                RuleFor(x => x.NewPassword).NotEmpty();

            }
        }
    }
}
