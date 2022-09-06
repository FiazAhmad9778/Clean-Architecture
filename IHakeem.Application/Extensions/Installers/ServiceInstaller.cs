using iHakeem.Domain.Doctors.ApplicationService;
using iHakeem.Domain.Doctors.IApplicationService;
using iHakeem.Domain.Patients.ApplicationService;
using iHakeem.Domain.Patients.IApplicationService;
using iHakeem.Domain.Users.UserVerificationCodes.DomainService;
using iHakeem.Domain.Users.UserVerificationCodes.IDomainService;
using iHakeem.Infrastructure.Common;
using Microsoft.Extensions.DependencyInjection;

namespace iHakeem.Application.Extensions.Installers
{
    public static class ServiceInstaller
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IPatientApplicationService, PatientApplicationService>();
            services.AddScoped<IDoctorApplicationService, DoctorApplicationService>();
            services.AddScoped<IDateTimeProvider, DateTimeProvider>();
            services.AddScoped<IUserVerficationCodeService, UserVerficationCodeService>();
            services.AddScoped<IEMRPatientHistoryService, EMRPatientHistoryService>();
            services.AddScoped<IVitalsPatientHistoryService, VitalsPatientHistoryService>();
        }
    }
}
