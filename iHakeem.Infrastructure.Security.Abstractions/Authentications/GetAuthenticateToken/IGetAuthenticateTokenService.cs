using System.Threading.Tasks;
using iHakeem.Infrastructure.Security.Abstractions.Authentications.Login;
using iHakeem.SharedKernal.BaseDomain;

namespace iHakeem.Infrastructure.Security.Abstractions.GetAuthenticateToken
{
    /// <summary>
    ///     Provides methods to deal with authorization.
    /// </summary>
    public interface IGetAuthenticateToken
    {
        /// <summary>
        ///     get user details form token
        /// </summary>
        /// <returns>Result user </returns>
        GetAuthenticateTokenResponseData GetUserFromToken();
        void FillAuditProperties(IAuditEntity auditEntity);
    }
}
