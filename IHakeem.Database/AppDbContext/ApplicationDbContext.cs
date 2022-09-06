using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using iHakeem.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace iHakeem.Database.AppDbContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, long>
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Culture> Cultures { get; set; }
        public DbSet<LocalizationSet> LocalizationSets { get; set; }
        public DbSet<Localization> Localizations { get; set; }
        public DbSet<MedicalDepartment> MedicalDepartments { get; set; }
        public DbSet<CurrentMedication> CurrentMedication { get; set; }
        public DbSet<PatientMedicalHistory> PatientMedicalHistory { get; set; }
        public DbSet<SocialHistory> SocialHistory { get; set; }
        public DbSet<RecreationalDrugsHistory> RecreationalDrugsHistory { get; set; }
        public DbSet<MyPhysicians> MyPhysicians { get; set; }
        public DbSet<ExerciseHistory> ExerciseHistory { get; set; }
        public DbSet<SurgicalHistory> SurgicalHistory { get; set; }
        public DbSet<UserVerificationCode> UserVerificationCodes { get; set; }
        public DbSet<PatientAllergiesHistory> PatientAllergiesHistory { get; set; }
        public DbSet<LookupData> LookupData { get; set; }
        public DbSet<Lookup> Lookup { get; set; }
        public DbSet<PharmacyInformation> PharmacyInformation { get; set; }
        public DbSet<HospitalizationInformation> HospitalizationInformation { get; set; }
        public DbSet<PatientGaurdian> PatientGaurdian { get; set; }
        public DbSet<PatientFamilyHistory> PatientFamilyHistory { get; set; }
        public DbSet<PatientHobbiesHistory> PatientHobbiesHistory { get; set; }
        public DbSet<PatientSocialInfo> PatientSocialInfo { get; set; }
        public DbSet<DoctorSocialInfo> DoctorSocialInfo { get; set; }
        public DbSet<SocialInfo> SocialInfo { get; set; }
        public DbSet<PatientEmergencyContact> PatientEmergencyContact { get; set; }
        public DbSet<PatientBloodPressure> PatientBloodPressure { get; set; }
        public DbSet<PulseOximeter> PulseOximeter { get; set; }
        public DbSet<PatientWeight> PatientWeight { get; set; }
        public DbSet<PatientTemperature> PatientTemperature { get; set; }
        public DbSet<UserPhotoAttachment> UserPhotoAttachment { get; set; }
        public DbSet<DoctorSkillsAndTraining> DoctorSkillsAndTraining { get; set; }
        public DbSet<DoctorEducation> DoctorEducation { get; set; }
        public DbSet<DoctorReference> DoctorReference { get; set; }
        public DbSet<DoctorMembership> DoctorMembership { get; set; }
        public DbSet<DoctorAwardsAndRecognition> DoctorAwardsAndRecognition { get; set; }
        public DbSet<DoctorLicenseAndCertification> DoctorLicenseAndCertification { get; set; }
        public DbSet<PatientMedication> PatientMedication { get; set; }
        public ApplicationDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);

        }
    }
}
