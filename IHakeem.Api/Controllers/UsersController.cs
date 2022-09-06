using iHakeem.Application.Users.CodeVerfication.CommandHandler.Generate;
using iHakeem.Application.Users.CodeVerfication.CommandHandler.Verify;
using iHakeem.Application.Users.ForgetPassword.ResetPassword;
using iHakeem.Application.Users.ForgetPassword.SendUrl;
using iHakeem.Application.Users.ForgetPassword.VerifyToken;
using iHakeem.Application.Users.UserDetails;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ApiControllerBase
    {
        public UsersController(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }



        [HttpPost("verifyCode")]
        public async Task<IActionResult> VerifyCode([FromBody] CodeVerificationRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }


        [HttpPost("generateCode")]
        public async Task<IActionResult> GenerateCode([FromBody] GenerateCodeRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }

        [HttpGet("userDetails")]
        public async Task<IActionResult> userDetails([FromQuery] GetUserDetailRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }

        [HttpPost("SendResetPasswordUrl")]
        public async Task<IActionResult> SendResetPasswordUrl([FromBody] SendResetPasswordUrlRequest request, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(request, cancellationToken);
            return HandleResponse(response);
        }

        [HttpPost("VerifyResetPasswordToken")]
        public async Task<IActionResult> VerifyResetPasswordToken([FromBody] VerifyResetPasswordTokenRequest request, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(request, cancellationToken);
            return HandleResponse(response);
        }

        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(request, cancellationToken);
            return HandleResponse(response);
        }
    }
}
