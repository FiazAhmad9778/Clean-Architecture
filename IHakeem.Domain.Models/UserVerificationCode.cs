using iHakeem.SharedKernal.BaseDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace iHakeem.Domain.Models
{
    public class UserVerificationCode : AuditEntity<int>
    {
        public long UserId { get; set; }
        public string Code { get; set; }
    }
}
