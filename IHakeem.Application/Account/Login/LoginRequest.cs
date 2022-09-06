using FluentValidation;
using iHakeem.Infrastructure.Security.Abstractions.Authentications.Login;
using MediatR;

namespace iHakeem.Application.Account.Login
{

    public class LoginRequest : LoginData, IRequest<LoginResponse>
    {
        private class LoginValidator : AbstractValidator<LoginRequest>
        {
            public LoginValidator()
            {
                RuleFor(e => e.UserName).NotEmpty();
                RuleFor(e => e.Password).NotEmpty();
            }
        }
    }
}
