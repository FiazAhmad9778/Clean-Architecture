using iHakeem.Infrastructure.Security.Abstractions.Authentications.Users;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace iHakeem.Domain.Models
{
    public class ApplicationUser : IdentityUser<long>, IUser
    {

        public override long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public override string UserName { get; set; }

        public override string Email { get; set; }
        public override string PhoneNumber { get; set; }
        public int Status { get; set; }
        public string TitleId { get; set; }
        public string GenderId { get; set; }
        public LookupData Title { get; set; }
        public LookupData Gender { get; set; }
        public UserPhotoAttachment Photo { get; set; }

    }
}
