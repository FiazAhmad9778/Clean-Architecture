using iHakeem.SharedKernal;
using System.Threading.Tasks;

namespace iHakeem.Infrastructure.Security.Abstractions.Authentications.Users
{
    public interface IUserManagementService<in TUser>
        where TUser : class, IUser
    {
        Task<CommonResult> Create(TUser user, string password, long? roleId);

        Task<CommonResult> Update(TUser user);

        Task<CommonResult> ChangePassword(long userId, string newPassword, string oldPassword);
        Task<bool> SendForgetPasswordUrl(string email, string url);
        Task<bool> VerifyResetPassToken(long userId, string token);
        Task<bool> resetPassword(long userId, string token, string password);

    }
}
