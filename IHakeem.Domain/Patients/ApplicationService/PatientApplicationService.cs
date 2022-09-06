using iHakeem.Domain.Models;
using iHakeem.Domain.Patients.IApplicationService;
using iHakeem.Domain.Patients.IDomainRepository;
using iHakeem.Domain.Users.IDomainRepository;
using iHakeem.Domain.Users.UserVerificationCodes.IDomainRepository;
using iHakeem.Domain.Users.UserVerificationCodes.IDomainService;
using iHakeem.Infrastructure.Common;
using iHakeem.Infrastructure.Common.Exceptions;
using iHakeem.Infrastructure.Security.Abstractions;
using iHakeem.Infrastructure.Security.Abstractions.Authentications.Users;
using iHakeem.Infrastructure.Security.Abstractions.Authorization.Roles;
using iHakeem.Infrastructure.Services.Mailing;
using iHakeem.Infrastructure.Services.TwilioMessanger;
using iHakeem.SharedKernal;
using iHakeem.SharedKernal.Constants;
using iHakeem.SharedKernal.Domain.IUnitOfWork;
using iHakeem.SharedKernal.Enums;
using iHakeem.SharedKernal.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace iHakeem.Domain.Patients.ApplicationService
{
    public class PatientApplicationService : IPatientApplicationService
    {
        private readonly IPatientRepository _patientReporsitory;
        private readonly IUserManagementService<ApplicationUser> _userManagementService;
        private readonly IUserRepository _userRepository;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMailer _mailer;
        private readonly IMessanger _messanger;
        private readonly IUserVerificationCodeRepository _userVerficationCodeRepository;
        private readonly IUserVerficationCodeService _userVerficationCodeService;
        private readonly IStringLocalizer _stringLocalizer;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly CommonMethods _commonMethods;

        public PatientApplicationService(IPatientRepository patientReporsitory,
            IUserManagementService<ApplicationUser> userManagementService,
            IUserRepository userRepository,
            IDateTimeProvider dateTimeProvider,
            IUnitOfWork unitOfWork,
            IMailer mailer,
            IMessanger messanger,
            IUserVerificationCodeRepository userVerficationCodeRepository,
            IUserVerficationCodeService userVerficationCodeService,
            IHttpContextAccessor httpContextAccessor,
            IStringLocalizer stringLocalizer)
        {
            _patientReporsitory = patientReporsitory;
            _userManagementService = userManagementService;
            _userRepository = userRepository;
            _dateTimeProvider = dateTimeProvider;
            _unitOfWork = unitOfWork;
            _mailer = mailer;
            _messanger = messanger;
            _userVerficationCodeRepository = userVerficationCodeRepository;
            _userVerficationCodeService = userVerficationCodeService;
            _stringLocalizer = stringLocalizer;
            _httpContextAccessor = httpContextAccessor;
            _commonMethods = new CommonMethods(_httpContextAccessor);
        }

        public async Task<Patient> RegisterPatient(Patient patient, string password, long roleId)
        {
            patient.User.Status = Convert.ToInt32(UserStatus.Pending);
            await _unitOfWork.RunTransaction(async () =>
            {
                var result = await _userManagementService.Create(patient.User, password, roleId);
                if (result.Succeeded)
                {
                    var code = StringUtils.GenerateFourDigitRandomNo();

                    patient.UserId = patient.User.Id;
                    patient.IsDeleted = false;
                    patient.CreatedDate = _dateTimeProvider.PlatformSpecificNow;
                    var patientResponse = await _patientReporsitory.Add(patient);
                    await _userVerficationCodeService.saveUserVerficationCode(patient.User.Id, code);
                    await _unitOfWork.SaveChangesAsync();
                    await _userVerficationCodeService.sendVerficationCodeEmailToUser(patient.User.FirstName + " " + patient.User.LastName, patient.User.Email, code);
                    //await sendVerficationCodeSMSToUser(user.FirstName + " " + user.LastName, user.PhoneNumber, code);
                }
                else
                {
                    throw new CodedException(ErrorCode.ValidationFailed);
                }
            });
            return patient;
        }


        public async Task<Patient> GetPatientByUserId(long UserId)
        {
            var result = await _patientReporsitory.GetSingle(s => s.UserId == UserId);
            return result;
        }
    }
}
