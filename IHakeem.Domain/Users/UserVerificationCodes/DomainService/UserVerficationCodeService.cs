using iHakeem.Domain.Models;
using iHakeem.Domain.Users.IDomainRepository;
using iHakeem.Domain.Users.UserVerificationCodes.IDomainRepository;
using iHakeem.Domain.Users.UserVerificationCodes.IDomainService;
using iHakeem.Infrastructure.Common;
using iHakeem.Infrastructure.Common.Exceptions;
using iHakeem.Infrastructure.Services.Mailing;
using iHakeem.Infrastructure.Services.TwilioMessanger;
using iHakeem.SharedKernal.Constants;
using iHakeem.SharedKernal.Domain.IUnitOfWork;
using iHakeem.SharedKernal.Enums;
using iHakeem.SharedKernal.Utils;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace iHakeem.Domain.Users.UserVerificationCodes.DomainService
{
    public class UserVerficationCodeService : IUserVerficationCodeService
    {
        private readonly IUserVerificationCodeRepository _userVerificationCodeRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDateTimeProvider _dateTimeProvide;
        private readonly IStringLocalizer _stringLocalizer;
        private readonly IMailer _mailer;
        private readonly IMessanger _messanger;

        public UserVerficationCodeService(IUserVerificationCodeRepository userVerificationCodeRepository,
            IUserRepository userRepository,
            IUnitOfWork unitOfWork,
            IDateTimeProvider dateTimeProvide,
            IStringLocalizer stringLocalizer,
               IMailer mailer,
            IMessanger messanger)
        {
            _userVerificationCodeRepository = userVerificationCodeRepository;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _dateTimeProvide = dateTimeProvide;
            _stringLocalizer = stringLocalizer;
            _mailer = mailer;
            _messanger = messanger;
        }
        public async Task<string> regenerateCode(long userId)
        {
            var user = await validateUserIfAlreadyActiveOrNotExist(userId);
            var userVerificationCode = await _userVerificationCodeRepository.GetSingle(x => x.UserId == userId);
            if (userVerificationCode == null) throw new CodedException(ErrorCode.InvalidUserId, _stringLocalizer[ErrorCode.InvalidUserId.ToString()].ToString());
            var code = StringUtils.GenerateFourDigitRandomNo();
            userVerificationCode.Code = code;
            userVerificationCode.UpdatedDate = _dateTimeProvide.PlatformSpecificNow;
            await _unitOfWork.SaveChangesAsync();
            await sendVerficationCodeEmailToUser(user.FirstName + " " + user.LastName, user.Email, code);
            return code;

        }

        public async Task verifyCode(long userId, string code)
        {
            await validateUserIfAlreadyActiveOrNotExist(userId);
            var userVerificationCode = await _userVerificationCodeRepository.GetSingle(x => x.UserId == userId && x.Code == code);
            if (userVerificationCode == null || (DateTime.UtcNow - userVerificationCode.UpdatedDate).Value.Hours > 1)
                throw new CodedException(ErrorCode.InvalidVerificationCode, _stringLocalizer[ErrorCode.InvalidVerificationCode.ToString()].ToString());

            var user = await _userRepository.GetSingle(x => x.Id == userId);
            user.Status = Convert.ToInt32(UserStatus.Active);
            await _unitOfWork.SaveChangesAsync();

        }

        public async Task<ApplicationUser> validateUserIfAlreadyActiveOrNotExist(long userId)
        {
            var user = await _userRepository.GetSingle(x => x.Id == userId);
            if (user == null || user?.Status != Convert.ToInt32(UserStatus.Pending))
                throw new CodedException(ErrorCode.InvalidUserId, _stringLocalizer[ErrorCode.InvalidUserId.ToString()].ToString());
            return user;

        }

        public async Task saveUserVerficationCode(long userId, string Code)
        {
            var verficationCode = new UserVerificationCode()
            {
                CreatedDate = _dateTimeProvide.PlatformSpecificNow,
                Code = Code,
                UpdatedDate = _dateTimeProvide.PlatformSpecificNow,
                UserId = userId
            };
            await _userVerificationCodeRepository.Add(verficationCode);
        }

        public async Task sendVerficationCodeEmailToUser(string userName, string email, string code)
        {
            var mailData = new MailData();
            var message = String.Format(UserMessagesStrings.welcomeMessage, userName, code);
            mailData.To = email;
            mailData.Subject = UserMessagesStrings.welcomeEmailSubject;
            mailData.Body = message;
            await _mailer.Send(mailData);
        }
        public async Task sendPatientCredentialEmailToUser(string Name, string userName, string password, string email)
        {
            var mailData = new MailData();
            var message = String.Format(UserMessagesStrings.patientRegistrationCredentials, Name, userName, password);
            mailData.To = email;
            mailData.Subject = UserMessagesStrings.welcomeEmailSubject;
            mailData.Body = message;
            await _mailer.Send(mailData);
        }
        public async Task sendVerficationCodeSMSToUser(string userName, string phoneNumber, string code)
        {
            var message = String.Format(UserMessagesStrings.welcomeMessage, userName, code);
            var messageData = new MessageData() { PhoneNo = phoneNumber, MessageText = message };
            await _messanger.SendSms(messageData);
        }

    }
}
