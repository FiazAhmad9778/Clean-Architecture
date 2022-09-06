namespace iHakeem.Infrastructure.Security.Abstractions.Authentications.Users
{
    public interface IUser
    {
        long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        string UserName { get; set; }
        string Email { get; set; }
        string PhoneNumber { get; set; }
        public int Status { get; set; }

    }
}
