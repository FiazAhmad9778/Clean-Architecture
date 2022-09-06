namespace iHakeem.Application.Users.Common
{
    public class UserSignupResponseDTO
    {
        public long UserId { get; set; } //from ApplicationUser table
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
    }
}
