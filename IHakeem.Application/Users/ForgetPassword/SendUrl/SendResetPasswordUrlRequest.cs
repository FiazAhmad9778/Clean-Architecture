using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace iHakeem.Application.Users.ForgetPassword.SendUrl
{
    public class SendResetPasswordUrlRequest : IRequest<bool>
    {
        public string Email { get; set; }
        public string Url { get; set; }
    }
}
