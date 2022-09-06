using System;
using System.Collections.Generic;
using System.Text;

namespace iHakeem.Infrastructure.Security.Abstractions.Authentications.Login
{
    public class LoginResponseData
    {
        public string Token { get; set; }
        public DateTime ExpiredOn { get; set; }
        public Boolean IsAuthenticated { get; set; }
    }
}
