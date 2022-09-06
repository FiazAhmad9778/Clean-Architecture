using iHakeem.Domain.Models;
using iHakeem.Infrastructure.Common.Exceptions;
using iHakeem.Infrastructure.Security.Abstractions.Authentications.Users;
using iHakeem.Infrastructure.Services.Mailing;
using iHakeem.SharedKernal;
using iHakeem.SharedKernal.Constants;
using iHakeem.SharedKernal.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using System;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace iHakeem.Infrastructure.Security.Core.Users
{
    internal class UserManagementService<TUser> : IUserManagementService<TUser>
        where TUser : class, IUser
    {
        private readonly UserManager<TUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IStringLocalizer _stringLocalizer;
        private readonly IMailer _mailer;

        public UserManagementService(
            UserManager<TUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            IStringLocalizer stringLocalizer,
            IMailer mailer
           )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _stringLocalizer = stringLocalizer;
            _mailer = mailer;
        }

        /// <summary>
        /// create user into the system after valdating
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <param name="roleId"></param>
        /// <returns>CommonResult</returns>
        public async Task<CommonResult> Create(TUser user, string password, long? roleId)
        {
            IdentityResult result = new IdentityResult();

            await ValidateUserName(user.UserName);
            await ValidateEmail(user.Email);
            ValidatePhoneNumber(user.PhoneNumber);

            result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded && roleId != null && roleId > 0)
            {
                var createdUser = await _userManager.FindByNameAsync(user.UserName);
                var role = _roleManager.Roles.FirstOrDefault(x => x.Id == roleId);
                await _userManager.AddToRoleAsync(createdUser, role.Name);
            }


            return MapResults(result);
        }

        public async Task<CommonResult> Update(TUser user)
        {
            IdentityResult result = await _userManager.UpdateAsync(user);
            return MapResults(result);
        }

        public async Task<CommonResult> ChangePassword(long userId, string newPassword, string oldPassword)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == userId && x.Status == Convert.ToInt32(UserStatus.Active));
            if (user == null || !await _userManager.CheckPasswordAsync(user, oldPassword))
            {
                throw new CodedException(ErrorCode.InValidOldPassword, _stringLocalizer[ErrorCode.InValidOldPassword.ToString()].ToString());
            }
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            IdentityResult result = await _userManager.ResetPasswordAsync(user, token, newPassword);
            return MapResults(result);
        }

        private CommonResult MapResults(IdentityResult result)
        {
            return new CommonResult(result.Succeeded, result.Errors?.Select(e => e.Code).ToArray());
        }

        /// <summary>
        /// validate if the user name already exist
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        private async Task ValidateUserName(string userName)
        {
            var existingUser = await _userManager.FindByNameAsync(userName);
            if (existingUser != null && existingUser.Status == Convert.ToInt32(UserStatus.Pending))
                throw new CodedException(ErrorCode.UserNamePendingRegisteration, generateErrorPayload(existingUser.Id, ErrorCode.UserNamePendingRegisteration.ToString()));
            if (existingUser != null)
                throw new CodedException(ErrorCode.UserNameAlreadyExist, _stringLocalizer[ErrorCode.UserNameAlreadyExist.ToString()].ToString());
        }
        /// <summary>
        /// validate if the email already exist
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        private async Task ValidateEmail(string email)
        {
            var existingUser = await _userManager.FindByEmailAsync(email);
            if (existingUser != null && existingUser.Status == Convert.ToInt32(UserStatus.Pending))
                throw new CodedException(ErrorCode.EmailPendingRegisteration, generateErrorPayload(existingUser.Id, ErrorCode.EmailPendingRegisteration.ToString()));
            if (existingUser != null)
                throw new CodedException(ErrorCode.EmailAlreadyExist, _stringLocalizer[ErrorCode.EmailAlreadyExist.ToString()].ToString());

        }
        /// <summary>
        /// Validate if the phone number already exist
        /// </summary>
        /// <param name="phoneNumber"></param>
        private void ValidatePhoneNumber(string phoneNumber)
        {
            var existingUser = _userManager.Users.FirstOrDefault(x => x.PhoneNumber == phoneNumber);
            if (existingUser != null && existingUser.Status == Convert.ToInt32(UserStatus.Pending))
                throw new CodedException(ErrorCode.PhoneNumberPendingRegisteration, generateErrorPayload(existingUser.Id, ErrorCode.PhoneNumberPendingRegisteration.ToString()));
            if (existingUser != null)
                throw new CodedException(ErrorCode.PhoneNumberAlreadyExist, _stringLocalizer[ErrorCode.PhoneNumberAlreadyExist.ToString()].ToString());
        }

        private dynamic generateErrorPayload(long userId, string errorCode)
        {
            dynamic payload = new ExpandoObject();
            payload.UserId = userId;
            payload.Message = _stringLocalizer[errorCode].ToString();
            return payload;

        }

        public async Task<bool> SendForgetPasswordUrl(string email, string url)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user != null)
            {
                string token = await _userManager.GeneratePasswordResetTokenAsync(user);
                string resetUrl = url + "?userId=" + user.Id + "&&token=" + token;
                await sendResetPasswordLinkToUser(user.FirstName + " " + user.LastName, email, resetUrl);
                return true;
            }

            throw new CodedException(ErrorCode.InvalidEmail);
        }

        public async Task<bool> VerifyResetPassToken(long userId, string token)
        {
            var user = _userManager.Users.SingleOrDefault(x => x.Id == userId);
            return await _userManager.VerifyUserTokenAsync(user, _userManager.Options.Tokens.PasswordResetTokenProvider, "ResetPassword", token);
        }

        public async Task<bool> resetPassword(long userId, string token, string password)
        {
            var user = _userManager.Users.SingleOrDefault(x => x.Id == userId);

            if (user != null && (await _userManager.ResetPasswordAsync(user, token, password)).Succeeded)
                return true;
            throw new CodedException(ErrorCode.InvalidResetPasswordToken);
        }

        public async Task sendResetPasswordLinkToUser(string username, string email, string url)
        {
            var mailData = new MailData();
            var message = String.Format(UserMessagesStrings.ResetPasswordMessage, username, url);
            mailData.To = email;
            mailData.Subject = UserMessagesStrings.welcomeEmailSubject;
            mailData.Body = message;
            await _mailer.Send(mailData);
        }
    }
}
