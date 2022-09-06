#region NameSpaces

using iHakeem.Domain.Departments.IDomainRepository;
using iHakeem.Domain.EMR.CurrentMedication.IDomainRepository;
using iHakeem.Domain.EMR.ExerciseHistory.IDomainRepository;
using iHakeem.Domain.EMR.MyPhysicians.IDomainRepository;
using iHakeem.Domain.EMR.PatientMedicalHistory.IDomainRepository;
using iHakeem.Domain.EMR.RecreationalDrugsHistory.IDomainRepository;
using iHakeem.Domain.EMR.SocialHistory.IDomainRepository;
using iHakeem.Domain.Patients.IDomainRepository;
using iHakeem.Domain.EMR.SurgicalHistory.IDomainRepository;
using iHakeem.Domain.Users.IDomainRepository;
using iHakeem.Infrastructure.Common.UntOfWork;
using iHakeem.Infrastructure.EF.Repositories;
using iHakeem.SharedKernal.Domain.IUnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using iHakeem.Domain.EMR.PatientAllergiesHistory.IDomainRepository;
using iHakeem.Domain.Users.UserVerificationCodes.IDomainRepository;
using iHakeem.Domain.Doctors.IDomainRepository;
using iHakeem.Domain.EMR.PharmacyInformation.IDomainRepository;
using iHakeem.Domain.EMR.HospitalizationInformation.IDomainRepository;
using iHakeem.Domain.Lookups.IDomainRepository;
using iHakeem.Domain.Patients.PatientGaurdians.IDomainRepository;
using iHakeem.Domain.EMR.EMRPatientHistory.IDomainRepository;
using iHakeem.Domain.EMR.PatientFamilyHistory.IDomainRepository;
using iHakeem.Domain.Patients.PatientSocialInfo.IDomainRepository;
using iHakeem.Domain.Files.IDomainRepository;
using iHakeem.Domain.EMR.PatientHobbiesHistory.IDomainRepository;
using iHakeem.Domain.EMR.PregnanciesHistory.IDomainRepository;
using iHakeem.Domain.EMR.DetailPregnancies.IDomainRepository;
using iHakeem.Domain.MyVitals.PatientBloodPressure.IDomainRepository;
using iHakeem.Domain.MyVitals.PulseOximeter.IDomainRepository;
using iHakeem.Domain.MyVitals.PatientWeight.IDomainRepository;
using iHakeem.Domain.MyVitals.PatientTemperature.IDomainRepository;
using iHakeem.Domain.EMR.VitalsPatientHistory.IDomainRepository;
using iHakeem.Domain.Doctors.Education;
using iHakeem.Domain.Doctors.TrainingAndSkills.IDomainRepository;
using iHakeem.Domain.Doctors.WorkExperience.IDomainRepository;
using iHakeem.Domain.Doctors.DoctorServices.IDomainRepository;
using iHakeem.Domain.Doctors.References.IDomainRepository;
using iHakeem.Domain.Doctors.Memberships.IDomainRepository;
using iHakeem.Domain.Doctors.AwardsAndRecognitions.IDomainRepository;
using iHakeem.Domain.Doctors.LicenseAndCertification.IDomainRepository;
using iHakeem.Domain.Patients.SocialInfo.IDomainRepository;
using iHakeem.Domain.Doctors.SocialInfo.IDomainRepository;
using iHakeem.Domain.Blogs.Categories.IDomainRepository;

#endregion
namespace iHakeem.Application.Extensions.Installers
{
    public static class RepositoryInstaller
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IMedicalDepartmentRepository, MedicalDepartmentRepository>();
            services.AddScoped<ICurrentMedicationRepository, CurrentMedicationRepository>();
            services.AddScoped<IPatientMedicalHistoryRepository, PatientMedicalHistoryRepository>();
            services.AddScoped<ISocialHistoryRepository, SocialHistoryRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IRecreationalDrugsHistoryRepository, RecreationalDrugsHistoryRepository>();
            services.AddScoped<IMyPhysiciansRepository, MyPhysiciansRepository>();
            services.AddScoped<IExerciseHistoryRepository, ExerciseHistoryRepository>();
            services.AddScoped<ISurgicalHistoryRepository, SurgicalHistoryRepository>();
            services.AddScoped<IPatientAllergiesHistoryRepository, PatientAllergiesHistoryRepository>();
            services.AddScoped<IUserVerificationCodeRepository, UserVerificationCodeRepository>();
            services.AddScoped<IPharmacyInformationRepository, PharmacyInformationRepository>();
            services.AddScoped<IHospitalizationInformationRepository, HospitalizationInformationRepository>();
            services.AddScoped<ILookupRepository, LookupRepository>();
            services.AddScoped<ILookupDataRepository, LookupDataRepository>();
            services.AddScoped<IPatientGaurdianRepository, PatientGaurdianRepository>();
            services.AddScoped<IEMRPatientHistoryRepository, EMRPatientHistoryRepository>();
            services.AddScoped<IPatientFamilyHistoryRepository, PatientFamilyHistoryRepository>();
            services.AddScoped<IPatientSocialInformationRepository, PatientSocialInformationRepository>();
            services.AddScoped<IDoctorSocialInformationRepository, DoctorSocialInformationRepository>();
            services.AddScoped<IPatientEmergencyContactRepository, PatientEmergencyContactRepository>();
            services.AddScoped<IFileRepository, FileRepository>();
            services.AddScoped<IPatientHobbiesHistoryRepository, PatientHobbiesHistoryRepository>();
            services.AddScoped<IPregnanciesHistoryRepository, PregnanciesHistoryRepository>();
            services.AddScoped<IDetailPregnanciesRepository, DetailPregnanciesRepository>();
            services.AddScoped<IPatientBloodPressureRepository, PatientBloodPressureRepository>();
            services.AddScoped<IPulseOximeterRepository, PulseOximeterRepository>();
            services.AddScoped<IPatientWeightRepository, PatientWeightRepository>();
            services.AddScoped<IPatientTemperatureRepository, PatientTemperatureRepository>();
            services.AddScoped<IVitalsPatientHistoryRepository, VitalsPatientHistoryRepository>();
            services.AddScoped<IDoctorEducationRepository, DoctorEducationRepository>();
            services.AddScoped<IDoctorSkillsAndTrainingRepository, DoctorSkillsAndTrainingRepository>();
            services.AddScoped<IDoctorWorkExperienceRepository, DoctorWorkExperienceRepository>();
            services.AddScoped<IDoctorServiceRepository, DoctorServiceRepository>();
            services.AddScoped<IDoctorReferenceRepository, DoctorReferenceRepository>();
            services.AddScoped<IDoctorMembershipRepository, DoctorMembershipRepository>();
            services.AddScoped<IDoctorAwardsAndRecognitionRepository, DoctorAwardsAndRecognitionRepository>();
            services.AddScoped<IDoctorLicenseAndCertificationRepository, DoctorLicenseAndCertificationRepository>();
            services.AddScoped<ICategoriesRepository, CategoriesRepository>();

        }
    }
}
