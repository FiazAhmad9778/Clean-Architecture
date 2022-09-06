using System;
using System.Collections.Generic;
using System.Text;

namespace iHakeem.Infrastructure.Security.Abstractions.GetAuthenticateToken
{
    public class GetAuthenticateTokenResponseData
    {
        public long UserId { get; set; }
        public long RoleId { get; set; }
        public string UserName { get; set; }
    }
}
