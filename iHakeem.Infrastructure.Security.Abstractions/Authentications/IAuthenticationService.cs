using System.Threading.Tasks;
using iHakeem.Infrastructure.Security.Abstractions.Authentications.Login;

namespace iHakeem.Infrastructure.Security.Abstractions.Authentications
{
    /// <summary>
    ///     Provides methods to deal with authorization.
    /// </summary>
    public interface IAuthenticationService
    {
        /// <summary>
        ///     Logs in user with provided credentials from <paramref name="loginData" />.
        /// </summary>
        /// <param name="loginData">The instance of <see cref="LoginData" />.</param>
        /// <returns>Result login operation.</returns>
        Task<LoginResponseData> LogInAsync(LoginData loginData);

        /// <summary>
        ///     Logs out user that performed request.
        /// </summary>
        /// <returns>A <see cref="Task" /> representing asynchronous operation.</returns>
        Task LogOutAsync();
    }
}
