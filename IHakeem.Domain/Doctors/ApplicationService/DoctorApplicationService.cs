using iHakeem.Domain.Models;
using iHakeem.Domain.Doctors.IApplicationService;
using iHakeem.Domain.Doctors.IDomainRepository;
using iHakeem.Domain.Users.IDomainRepository;
using iHakeem.Domain.Users.UserVerificationCodes.IDomainRepository;
using iHakeem.Domain.Users.UserVerificationCodes.IDomainService;
using iHakeem.Infrastructure.Common;
using iHakeem.Infrastructure.Common.Exceptions;
using iHakeem.Infrastructure.Security.Abstractions.Authentications.Users;
using iHakeem.Infrastructure.Services.Mailing;
using iHakeem.Infrastructure.Services.TwilioMessanger;
using iHakeem.SharedKernal.Constants;
using iHakeem.SharedKernal.Domain.IUnitOfWork;
using iHakeem.SharedKernal.Enums;
using iHakeem.SharedKernal.Utils;
using Microsoft.Extensions.Localization;
using System;
using System.Threading.Tasks;

namespace iHakeem.Domain.Doctors.ApplicationService
{
    public class DoctorApplicationService : IDoctorApplicationService
    {
        private readonly IDoctorRepository _DoctorReporsitory;
        private readonly IUserManagementService<ApplicationUser> _userManagementService;
        private readonly IUserRepository _userRepository;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMailer _mailer;
        private readonly IMessanger _messanger;
        private readonly IUserVerificationCodeRepository _userVerficationCodeRepository;
        private readonly IUserVerficationCodeService _userVerficationCodeService;
        private readonly IStringLocalizer _stringLocalizer;

        public DoctorApplicationService(IDoctorRepository DoctorReporsitory,
            IUserManagementService<ApplicationUser> userManagementService,
            IUserRepository userRepository,
            IDateTimeProvider dateTimeProvider,
            IUnitOfWork unitOfWork,
            IMailer mailer,
            IMessanger messanger,
            IUserVerificationCodeRepository userVerficationCodeRepository,
            IUserVerficationCodeService userVerficationCodeService,
            IStringLocalizer stringLocalizer)
        {
            _DoctorReporsitory = DoctorReporsitory;
            _userManagementService = userManagementService;
            _userRepository = userRepository;
            _dateTimeProvider = dateTimeProvider;
            _unitOfWork = unitOfWork;
            _mailer = mailer;
            _messanger = messanger;
            _userVerficationCodeRepository = userVerficationCodeRepository;
            _userVerficationCodeService = userVerficationCodeService;
            _stringLocalizer = stringLocalizer;
        }

        public async Task<Doctor> RegisterDoctor(Doctor doctor, string password, long roleId)
        {
            doctor.User.Status = Convert.ToInt32(UserStatus.Pending);
            await _unitOfWork.RunTransaction(async () =>
            {
                var result = await _userManagementService.Create(doctor.User, password, roleId);
                if (result.Succeeded)
                {
                    var code = StringUtils.GenerateFourDigitRandomNo();
                    doctor.CreatedDate = _dateTimeProvider.PlatformSpecificNow;
                    var DoctorResponse = await _DoctorReporsitory.Add(doctor);
                    await _userVerficationCodeService.saveUserVerficationCode(doctor.User.Id, code);
                    await _unitOfWork.SaveChangesAsync();
                    await _userVerficationCodeService.sendVerficationCodeEmailToUser(doctor.User.FirstName + " " + doctor.User.LastName, doctor.User.Email, code);
                    //await sendVerficationCodeSMSToUser(user.FirstName + " " + user.LastName, user.PhoneNumber, code);

                }
                else
                {
                    throw new CodedException(ErrorCode.ValidationFailed);
                }
            });
            return doctor;
        }

    }
}
