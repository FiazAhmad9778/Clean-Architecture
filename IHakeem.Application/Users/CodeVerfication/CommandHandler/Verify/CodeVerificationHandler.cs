using iHakeem.Domain.Patients.IApplicationService;
using iHakeem.Domain.Users.UserVerificationCodes.IDomainService;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.Users.CodeVerfication.CommandHandler.Verify
{
    public class CodeVerificationHandler : IRequestHandler<CodeVerificationRequestDTO, Unit>
    {
        private readonly IUserVerficationCodeService _userVerficationCodeService;

        public CodeVerificationHandler(IUserVerficationCodeService userVerficationCodeService)
        {
            _userVerficationCodeService = userVerficationCodeService;
        }

        public async Task<Unit> Handle(CodeVerificationRequestDTO request,
            CancellationToken cancellationToken)
        {

            await _userVerficationCodeService.verifyCode(request.UserId, request.Code);

            return Unit.Value;
        }
    }
}
