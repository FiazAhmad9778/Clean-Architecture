namespace iHakeem.Infrastructure.Security.Abstractions.Authentications.Login
{
    /// <summary>
    /// Represents a login data for sign-in operation.
    /// </summary>
    public class LoginData
    {
        /// <summary>
        /// Gets or sets an user name an user to login.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets a password of an user to sign-in.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the sign-in cookie should persist after the browser is closed.
        /// </summary>
        public bool RememberMe { get; set; }
    }
}
