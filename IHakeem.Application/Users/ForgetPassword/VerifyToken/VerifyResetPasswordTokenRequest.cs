using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace iHakeem.Application.Users.ForgetPassword.VerifyToken
{
    public class VerifyResetPasswordTokenRequest : IRequest<bool>
    {
        public string Token { get; set; }
    }
}
