using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace iHakeem.Application.Users.ForgetPassword.ResetPassword
{
    public class ResetPasswordRequest : IRequest<bool>
    {
        public string Token { get; set; }
        public string Password { get; set; }
    }
}
