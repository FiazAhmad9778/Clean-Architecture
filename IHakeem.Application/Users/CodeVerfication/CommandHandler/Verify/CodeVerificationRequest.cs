using FluentValidation;
using MediatR;

namespace iHakeem.Application.Users.CodeVerfication.CommandHandler.Verify
{
    public class CodeVerificationRequestDTO : IRequest<Unit>
    {
        public long UserId { get; set; }
        public string Code { get; set; }

        public class CodeVerificationRequestDTOValidator : AbstractValidator<CodeVerificationRequestDTO>
        {
            public CodeVerificationRequestDTOValidator()
            {
                RuleFor(x => x.UserId).NotEmpty();
                RuleFor(x => x.Code).NotEmpty();

            }
        }
    }
}
