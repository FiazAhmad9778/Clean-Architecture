using iHakeem.Application.Account.Login;
using iHakeem.Application.Account.Logout;
using iHakeem.Application.Users.ChangePassword;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ApiControllerBase
    {
        public AuthController(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request, CancellationToken cancellationToken)
        {
            return HandleResponse(await Mediator.Send(request, cancellationToken));
        }


        [AllowAnonymous]
        [HttpPost("logout")]
        public async Task Logout()
        {
            await Mediator.Send(new LogoutRequest());
        }


        [Authorize]
        [HttpPost("changePassword")]
        public async Task<IActionResult> changePassword([FromBody] ChangePasswordRequestDTO request, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(request, cancellationToken);
            return HandleResponse(response);
        }

    }
}
