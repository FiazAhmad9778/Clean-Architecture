using System;
using System.Collections.Generic;
using System.Text;

namespace iHakeem.Application.Users.UserDetails
{
    public class UserDetailResponseDTO
    {
        public long Id { get; set; } //from ApplicationUser table
        public long RoleId { get; set; } //from ApplicationUser table
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
    }
}
