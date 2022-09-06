using iHakeem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace iHakeem.Domain.Users.UserVerificationCodes.IDomainService
{
    public interface IUserVerficationCodeService
    {
        Task verifyCode(long userId, string code);
        Task<string> regenerateCode(long userId);
        Task<ApplicationUser> validateUserIfAlreadyActiveOrNotExist(long userId);
        Task saveUserVerficationCode(long userId, string Code);
        Task sendVerficationCodeEmailToUser(string userName, string email, string code);
        Task sendVerficationCodeSMSToUser(string userName, string phoneNumber, string code);
        Task sendPatientCredentialEmailToUser(string Name, string userName, string password, string email);

    }
}
