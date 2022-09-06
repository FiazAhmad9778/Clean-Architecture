#region MyRegion
using AutoMapper;
using iHakeem.Application.Account.Login;
using iHakeem.Application.Blogs.Categories.CommandHandlers.CreateOrUpdate;
using iHakeem.Application.Blogs.Categories.Contracts;
using iHakeem.Application.Doctors.AwardsAndRecognition.Contracts;
using iHakeem.Application.Doctors.CommandHandler.Signup;
using iHakeem.Application.Doctors.Contracts;
using iHakeem.Application.Doctors.DoctorAwardsAndRecognitions.CommadHandler.Create;
using iHakeem.Application.Doctors.DoctorServices.CommadHandler.Create;
using iHakeem.Application.Doctors.DoctorServices.Contracts;
using iHakeem.Application.Doctors.Education.CommadHandler.Create;
using iHakeem.Application.Doctors.Education.Contracts;
using iHakeem.Application.Doctors.Memberships.CommadHandler.Create;
using iHakeem.Application.Doctors.Memberships.Contracts;
using iHakeem.Application.Doctors.PersonalInfo.CommadHandler.Update;
using iHakeem.Application.Doctors.PersonalInfo.Contracts;
using iHakeem.Application.Doctors.Reference.CommadHandler.Create;
using iHakeem.Application.Doctors.References.Contracts;
using iHakeem.Application.Doctors.SkillsAndtraining.CommadHandler.Create;
using iHakeem.Application.Doctors.SkillsAndtraining.Contracts;
using iHakeem.Application.Doctors.SocialInfo.CommadHandler.Create;
using iHakeem.Application.Doctors.SocialInfo.Contracts;
using iHakeem.Application.Doctors.WorkExperience.CommadHandler.Create;
using iHakeem.Application.Doctors.WorkExperience.Contracts;
using iHakeem.Application.EMR.CurrentMedication.CommandHandlers.Create;
using iHakeem.Application.EMR.CurrentMedication.CommandHandlers.Delete;
using iHakeem.Application.EMR.CurrentMedication.CommandHandlers.Edit;
using iHakeem.Application.EMR.CurrentMedication.Contracts;
using iHakeem.Application.EMR.DetailPregnancies.CommandHandlers.CreateOrUpdate;
using iHakeem.Application.EMR.DetailPregnancies.CommandHandlers.Delete;
using iHakeem.Application.EMR.DetailPregnancies.Contracts;
using iHakeem.Application.EMR.EMRPatientHistory.Contracts;
using iHakeem.Application.EMR.ExerciseHistory.CommandHandlers.Create;
using iHakeem.Application.EMR.ExerciseHistory.CommandHandlers.Delete;
using iHakeem.Application.EMR.ExerciseHistory.CommandHandlers.Edit;
using iHakeem.Application.EMR.ExerciseHistory.Contracts;
using iHakeem.Application.EMR.HospitalizationInformation.CommandHandlers.Create;
using iHakeem.Application.EMR.HospitalizationInformation.CommandHandlers.Delete;
using iHakeem.Application.EMR.HospitalizationInformation.CommandHandlers.Edit;
using iHakeem.Application.EMR.HospitalizationInformation.Contracts;
using iHakeem.Application.EMR.MyPhysicians.CommandHandlers.Create;
using iHakeem.Application.EMR.MyPhysicians.CommandHandlers.Delete;
using iHakeem.Application.EMR.MyPhysicians.CommandHandlers.Edit;
using iHakeem.Application.EMR.MyPhysicians.Contracts;
using iHakeem.Application.EMR.PatientAllergiesHistory.CommandHandlers.Create;
using iHakeem.Application.EMR.PatientAllergiesHistory.CommandHandlers.Delete;
using iHakeem.Application.EMR.PatientAllergiesHistory.CommandHandlers.Edit;
using iHakeem.Application.EMR.PatientAllergiesHistory.Contracts;
using iHakeem.Application.EMR.PatientFamilyHistory.CommandHandlers.CreateOrUpdate;
using iHakeem.Application.EMR.PatientFamilyHistory.CommandHandlers.Delete;
using iHakeem.Application.EMR.PatientFamilyHistory.Contracts;
using iHakeem.Application.EMR.PatientHobbiesHistory.CommandHandlers.CreateOrUpdate;
using iHakeem.Application.EMR.PatientHobbiesHistory.CommandHandlers.Delete;
using iHakeem.Application.EMR.PatientHobbiesHistory.Contracts;
using iHakeem.Application.EMR.PatientMedicalHistory.CommandHandlers.Create;
using iHakeem.Application.EMR.PatientMedicalHistory.CommandHandlers.Delete;
using iHakeem.Application.EMR.PatientMedicalHistory.CommandHandlers.Edit;
using iHakeem.Application.EMR.PatientMedicalHistory.Contracts;
using iHakeem.Application.EMR.PharmacyInformation.CommandHandlers.Create;
using iHakeem.Application.EMR.PharmacyInformation.CommandHandlers.Delete;
using iHakeem.Application.EMR.PharmacyInformation.CommandHandlers.Edit;
using iHakeem.Application.EMR.PharmacyInformation.Contracts;
using iHakeem.Application.EMR.PregnanciesHistory.CommandHandlers.CreateOrUpdate;
using iHakeem.Application.EMR.PregnanciesHistory.CommandHandlers.Delete;
using iHakeem.Application.EMR.PregnanciesHistory.Contracts;
using iHakeem.Application.EMR.RecreationalDrugsHistory.CommandHandlers.Create;
using iHakeem.Application.EMR.RecreationalDrugsHistory.CommandHandlers.Delete;
using iHakeem.Application.EMR.RecreationalDrugsHistory.CommandHandlers.Edit;
using iHakeem.Application.EMR.RecreationalDrugsHistory.Contracts;
using iHakeem.Application.EMR.SocialHistory.CommandHandlers.Create;
using iHakeem.Application.EMR.SocialHistory.CommandHandlers.Delete;
using iHakeem.Application.EMR.SocialHistory.CommandHandlers.Edit;
using iHakeem.Application.EMR.SocialHistory.Contracts;
using iHakeem.Application.EMR.SurgicalHistory.CommandHandlers.Create;
using iHakeem.Application.EMR.SurgicalHistory.CommandHandlers.Delete;
using iHakeem.Application.EMR.SurgicalHistory.CommandHandlers.Edit;
using iHakeem.Application.EMR.SurgicalHistory.Contracts;
using iHakeem.Application.Lookup.Contracts;
using iHakeem.Application.Lookup.Create;
using iHakeem.Application.MyVitals.PatientBloodPressure.CommandHandlers.CreateOrUpdate;
using iHakeem.Application.MyVitals.PatientBloodPressure.CommandHandlers.Delete;
using iHakeem.Application.MyVitals.PatientBloodPressure.Contracts;
using iHakeem.Application.MyVitals.PatientTemperature.CommandHandlers.CreateOrUpdate;
using iHakeem.Application.MyVitals.PatientTemperature.CommandHandlers.Delete;
using iHakeem.Application.MyVitals.PatientTemperature.Contracts;
using iHakeem.Application.MyVitals.PatientWeight.CommandHandlers.CreateOrUpdate;
using iHakeem.Application.MyVitals.PatientWeight.CommandHandlers.Delete;
using iHakeem.Application.MyVitals.PatientWeight.Contracts;
using iHakeem.Application.MyVitals.PulseOximeter.CommandHandlers.CreateOrUpdate;
using iHakeem.Application.MyVitals.PulseOximeter.CommandHandlers.Delete;
using iHakeem.Application.MyVitals.PulseOximeter.Contracts;
using iHakeem.Application.MyVitals.VitalsPatientHistory.Contracts;
using iHakeem.Application.Patients.CommandHandler.Signup;
using iHakeem.Application.Patients.Contracts;
using iHakeem.Application.Patients.EmergencyContact.CommadHandler.Create;
using iHakeem.Application.Patients.EmergencyContact.Contracts;
using iHakeem.Application.Patients.PatientGaurdians.CommandHandlers.CreateOrUpdate;
using iHakeem.Application.Patients.PatientGaurdians.Contracts;
using iHakeem.Application.Patients.PersonalInfo.CommadHandler.Update;
using iHakeem.Application.Patients.PersonalInfo.Contracts;
using iHakeem.Application.Patients.SignUp.Contracts;
using iHakeem.Application.Patients.SocialInfo.CommadHandler.Create;
using iHakeem.Application.Patients.SocialInfo.Contracts;
using iHakeem.Application.Users.UserDetails;
using iHakeem.Domain.Models;
using iHakeem.Infrastructure.FileStorage;
using iHakeem.Infrastructure.Security.Abstractions.Authentications.Login;
using Microsoft.AspNetCore.Http;
#endregion

namespace iHakeem.Application.Extensions.AutoMapperConfigurations
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LoginResponseData, LoginResponse>(MemberList.None);
            CreateMap<ApplicationUser, UserDetailResponseDTO>(MemberList.None);

            #region Patient
            CreateMap<PatientSignupRequestDTO, Patient>(MemberList.None);
            CreateMap<PatientSignupRequestDTO, ApplicationUser>(MemberList.None);
            CreateMap<Patient, PatientSignupResponseDTO>(MemberList.None);
            CreateMap<ApplicationUser, PatientSignupResponseDTO>(MemberList.None);
            CreateMap<PatientPersonalInfoUpdateRequestDTO, Patient>(MemberList.None);
            CreateMap<PatientSocialInfo, PatientSocialInfoDTO>(MemberList.None).ReverseMap();
            CreateMap<PatientSocialInfoCreateRequestDTO, PatientSocialInfo>()
                .ForPath(x => x.SocialInformation.Name, x => x.MapFrom(s => s.Name))
                .ForPath(x => x.SocialInformation.Url, x => x.MapFrom(s => s.Url))
                .ForPath(x => x.SocialInformation.Id, x => x.MapFrom(s => s.Id))
                .ForPath(x => x.SocialInformationId, x => x.MapFrom(s => s.Id))
                .ReverseMap();
            CreateMap<PatientSocialInfo, PatientSocialInfoDTO>()
                .ForPath(x => x.Name, x => x.MapFrom(s => s.SocialInformation.Name))
                .ForPath(x => x.Url, x => x.MapFrom(s => s.SocialInformation.Url))
                .ForPath(x => x.Id, x => x.MapFrom(s => s.SocialInformationId))
                .ReverseMap();

            CreateMap<PatientEmergencyContact, PatientEmergencyContactDTO>(MemberList.None).ReverseMap();
            CreateMap<PatientEmergencyContactCreateRequestDTO, PatientEmergencyContact>(MemberList.None).ReverseMap();
            CreateMap<IFormFile, UploadFileRequest>(MemberList.None)
                .ForMember(x => x.SizeBytes, x => x.MapFrom(xs => xs.Length))
                .ForMember(x => x.GetStream, x => x.MapFrom(xs => xs.OpenReadStream()));
            CreateMap<UploadFileRequest, File>(MemberList.None).ReverseMap();
            CreateMap<FileReference, File>(MemberList.None).ReverseMap();
            CreateMap<Patient, PatientPersonalInfoResponseDTO>()
                .ForMember(x => x.FirstName, x => x.MapFrom(xs => xs.User.FirstName))
                .ForMember(x => x.LastName, x => x.MapFrom(xs => xs.User.LastName))
                .ForMember(x => x.GenderId, x => x.MapFrom(xs => xs.User.GenderId))
                .ForMember(x => x.TitleId, x => x.MapFrom(xs => xs.User.TitleId))
                .ForMember(x => x.Email, x => x.MapFrom(xs => xs.User.Email))
                .ForMember(x => x.PhoneNumber, x => x.MapFrom(xs => xs.User.PhoneNumber))
                .ForMember(x => x.TitleText, x => x.MapFrom(xs => xs.User.Title == null ? "" : xs.User.Title.Value))
                .ForMember(x => x.GenderText, x => x.MapFrom(xs => xs.User.Gender == null ? "" : xs.User.Gender.Value))
                .ForMember(x => x.EthnicityText, x => x.MapFrom(xs => xs.Ethnicity == null ? "" : xs.Ethnicity.Value))
                .ForMember(x => x.MaritialStatusText, x => x.MapFrom(xs => xs.MaritialStatus == null ? "" : xs.MaritialStatus.Value))
                .ForMember(x => x.PreferedLanguageText, x => x.MapFrom(xs => xs.PreferedLanguage == null ? "" : xs.PreferedLanguage.Value))
                .ForMember(x => x.BloodGroupText, x => x.MapFrom(xs => xs.BloodGroup == null ? "" : xs.BloodGroup.Value));

            #endregion

            #region PatientGaurdian
            CreateMap<CreateOrUpdatePatientGaurdianRequestDTO, PatientGaurdian>(MemberList.None);
            CreateMap<PatientGaurdian, PatientGaurdianResponseDTO>(MemberList.None);
            CreateMap<PatientGaurdian, PatientGaurdianResponseDTO>(MemberList.None);
            #endregion


            #region Doctor
            CreateMap<DoctorSignupRequestDTO, Doctor>(MemberList.None);
            CreateMap<DoctorSignupRequestDTO, ApplicationUser>(MemberList.None);
            CreateMap<Doctor, DoctorSignupResponseDTO>(MemberList.None);
            CreateMap<ApplicationUser, DoctorSignupResponseDTO>(MemberList.None);
            CreateMap<Doctor, DoctorPersonalInfoResponseDTO>(MemberList.None);
            CreateMap<DoctorPersonalInfoUpdateRequestDTO, Doctor>(MemberList.None);
            CreateMap<DoctorEducationDTO, DoctorEducation>().ReverseMap();
            CreateMap<DoctorEducationCreateRequestDTO, DoctorEducation>().ReverseMap();
            CreateMap<DoctorSkillsAndTrainingDTO, DoctorSkillsAndTraining>().ReverseMap();
            CreateMap<DoctorSkillsAndTrainingCreateRequestDTO, DoctorSkillsAndTraining>().ReverseMap();
            CreateMap<DoctorWorkExperienceDTO, DoctorWorkExperience>().ReverseMap();
            CreateMap<DoctorWorkExperienceCreateRequestDTO, DoctorWorkExperience>().ReverseMap();
            CreateMap<DoctorServiceDTO, DoctorService>().ReverseMap();
            CreateMap<DoctorServiceCreateRequestDTO, DoctorService>().ReverseMap();
            CreateMap<DoctorAwardsAndRecognitionDTO, DoctorAwardsAndRecognition>().ReverseMap();
            CreateMap<DoctorAwardsAndRecognitionCreateRequestDTO, DoctorAwardsAndRecognition>().ReverseMap();
            CreateMap<DoctorLicenseAndCertificationDTO, DoctorLicenseAndCertification>().ReverseMap();
            CreateMap<DoctorMembershipDTO, DoctorMembership>().ReverseMap();
            CreateMap<DoctorMembershipCreateRequestDTO, DoctorMembership>().ReverseMap();
            CreateMap<DoctorReferenceDTO, DoctorReference>().ReverseMap();
            CreateMap<DoctorReferenceCreateRequestDTO, DoctorReference>().ReverseMap();
            CreateMap<DoctorSocialInfoCreateRequestDTO, DoctorSocialInfo>()
               .ForPath(x => x.SocialInformation.Name, x => x.MapFrom(s => s.Name))
               .ForPath(x => x.SocialInformation.Url, x => x.MapFrom(s => s.Url))
               .ForPath(x => x.SocialInformation.Id, x => x.MapFrom(s => s.Id))
               .ForPath(x => x.SocialInformationId, x => x.MapFrom(s => s.Id))
               .ReverseMap();
            CreateMap<DoctorSocialInfo, DoctorSocialInfoDTO>();
            CreateMap<DoctorSocialInfo, DoctorSocialInfoDTO>()
               .ForPath(x => x.Name, x => x.MapFrom(s => s.SocialInformation.Name))
               .ForPath(x => x.Url, x => x.MapFrom(s => s.SocialInformation.Url))
               .ForPath(x => x.Id, x => x.MapFrom(s => s.SocialInformationId))
               .ReverseMap();
            #endregion

            #region Lookup
            CreateMap<LookupData, LookupResponseDTO>(MemberList.None);
            CreateMap<CreateOrUpdateLookupRequestDTO, LookupData>(MemberList.None);
            #endregion

            #region EMR

            #region Current Medication

            CreateMap<CreateCurrentMedicationRequestDTO, CurrentMedication>(MemberList.None);
            CreateMap<EditCurrentMedicationRequestDTO, CurrentMedication>(MemberList.None);
            CreateMap<DeleteCurrentMedicationRequestDTO, CurrentMedication>(MemberList.None);


            CreateMap<CurrentMedication, CurrentMedicationResponseDTO>(MemberList.None);

            #endregion

            #region Patient Medication History

            CreateMap<CreatePatientMedicalHistoryRequestDTO, PatientMedicalHistory>(MemberList.None);
            CreateMap<EditPatientMedicalHistoryRequestDTO, PatientMedicalHistory>(MemberList.None);
            CreateMap<DeletePatientMedicalHistoryRequestDTO, PatientMedicalHistory>(MemberList.None);

            CreateMap<PatientMedicalHistory, PatientMedicalHistoryResponseDTO>(MemberList.None);

            #endregion

            #region Social History

            CreateMap<CreateSocialHistoryRequestDTO, SocialHistory>(MemberList.None);
            CreateMap<EditSocialHistoryRequestDTO, SocialHistory>(MemberList.None);
            CreateMap<DeleteSocialHistoryRequestDTO, SocialHistory>(MemberList.None);

            CreateMap<SocialHistory, SocialHistoryResponseDTO>(MemberList.None);
            #endregion

            #region Recreational Drugs History

            CreateMap<CreateRecreationalDrugsHistoryRequestDTO, RecreationalDrugsHistory>(MemberList.None);
            CreateMap<EditRecreationalDrugsHistoryRequestDTO, RecreationalDrugsHistory>(MemberList.None);
            CreateMap<DeleteRecreationalDrugsHistoryRequestDTO, RecreationalDrugsHistory>(MemberList.None);

            CreateMap<RecreationalDrugsHistory, RecreationalDrugsHistoryResponseDTO>(MemberList.None);
            #endregion

            #region My Physicians

            CreateMap<CreateMyPhysiciansRequestDTO, MyPhysicians>(MemberList.None);
            CreateMap<EditMyPhysiciansRequestDTO, MyPhysicians>(MemberList.None);
            CreateMap<DeleteMyPhysiciansRequestDTO, MyPhysicians>(MemberList.None);

            CreateMap<MyPhysicians, MyPhysiciansResponseDTO>(MemberList.None);
            #endregion

            #region Exercise History

            CreateMap<CreateExerciseHistoryRequestDTO, ExerciseHistory>(MemberList.None);
            CreateMap<EditExerciseHistoryRequestDTO, ExerciseHistory>(MemberList.None);
            CreateMap<DeleteExerciseHistoryRequestDTO, ExerciseHistory>(MemberList.None);

            CreateMap<ExerciseHistory, ExerciseHistoryResponseDTO>(MemberList.None);
            #endregion

            #region Surgical History

            CreateMap<CreateSurgicalHistoryRequestDTO, SurgicalHistory>(MemberList.None);
            CreateMap<EditSurgicalHistoryRequestDTO, SurgicalHistory>(MemberList.None);
            CreateMap<DeleteSurgicalHistoryRequestDTO, SurgicalHistory>(MemberList.None);

            CreateMap<SurgicalHistory, SurgicalHistoryResponseDTO>(MemberList.None);
            #endregion

            #region Patient Allergy History

            CreateMap<CreatePatientAllergiesHistoryRequestDTO, PatientAllergiesHistory>(MemberList.None);
            CreateMap<EditPatientAllergiesHistoryRequestDTO, PatientAllergiesHistory>(MemberList.None);
            CreateMap<DeletePatientAllergiesHistoryRequestDTO, PatientAllergiesHistory>(MemberList.None);

            CreateMap<PatientAllergiesHistory, PatientAllergiesHistoryResponseDTO>(MemberList.None);
            #endregion

            #region Pharmacy Information

            CreateMap<CreatePharmacyInformationRequestDTO, PharmacyInformation>(MemberList.None);
            CreateMap<EditPharmacyInformationRequestDTO, PharmacyInformation>(MemberList.None);
            CreateMap<DeletePharmacyInformationRequestDTO, PharmacyInformation>(MemberList.None);

            CreateMap<PharmacyInformation, PharmacyInformationResponseDTO>(MemberList.None);
            #endregion

            #region Hospitalization Information

            CreateMap<CreateHospitalizationInformationRequestDTO, HospitalizationInformation>(MemberList.None);
            CreateMap<EditHospitalizationInformationRequestDTO, HospitalizationInformation>(MemberList.None);
            CreateMap<DeleteHospitalizationInformationRequestDTO, HospitalizationInformation>(MemberList.None);

            CreateMap<HospitalizationInformation, HospitalizationInformationResponseDTO>(MemberList.None);
            #endregion

            #region Patient Family History

            CreateMap<CreateOrUpdatePatientFamilyHistoryRequestDTO, PatientFamilyHistory>(MemberList.None);
            CreateMap<PatientFamilyHistoryDeleteRequestDTO, PatientFamilyHistory>(MemberList.None);

            CreateMap<PatientFamilyHistory, PatientFamilyHistoryResponseDTO>(MemberList.None);
            #endregion

            #region Patient Hobbies History

            CreateMap<CreateOrUpdatePatientHobbiesHistoryRequestDTO, PatientHobbiesHistory>(MemberList.None);
            CreateMap<PatientHobbiesHistoryDeleteRequestDTO, PatientHobbiesHistory>(MemberList.None);

            CreateMap<PatientHobbiesHistory, PatientHobbiesHistoryResponseDTO>(MemberList.None);
            #endregion

            #region Pregnancies History

            CreateMap<CreateOrUpdatePregnanciesHistoryRequestDTO, PregnanciesHistory>(MemberList.None);
            CreateMap<PregnanciesHistoryDeleteRequestDTO, PregnanciesHistory>(MemberList.None);

            CreateMap<PregnanciesHistory, PregnanciesHistoryResponseDTO>(MemberList.None);
            #endregion

            #region Detail Pregnancies

            CreateMap<CreateOrUpdateDetailPregnanciesRequestDTO, DetailPregnancies>(MemberList.None);
            CreateMap<DetailPregnanciesDeleteRequestDTO, DetailPregnancies>(MemberList.None);

            CreateMap<DetailPregnancies, DetailPregnanciesResponseDTO>(MemberList.None);
            #endregion

            CreateMap<GetAllPatientHistory, EMRPatientHistoryResponseDTO>(MemberList.None);

            #endregion

            #region MyVitals
            #region Blood Pressure

            CreateMap<CreateOrUpdatePatientBloodPressureRequestDTO, PatientBloodPressure>(MemberList.None);
            CreateMap<PatientBloodPressureDeleteRequestDTO, PatientBloodPressure>(MemberList.None);

            CreateMap<PatientBloodPressure, PatientBloodPressureResponseDTO>(MemberList.None);
            #endregion

            #region Pulse Oximeter

            CreateMap<CreateOrUpdatePulseOximeterRequestDTO, PulseOximeter>(MemberList.None);
            CreateMap<PulseOximeterDeleteRequestDTO, PulseOximeter>(MemberList.None);

            CreateMap<PulseOximeter, PulseOximeterResponseDTO>(MemberList.None);
            #endregion

            #region Patient Weight

            CreateMap<CreateOrUpdatePatientWeightRequestDTO, PatientWeight>(MemberList.None);
            CreateMap<PatientWeightDeleteRequestDTO, PatientWeight>(MemberList.None);

            CreateMap<PatientWeight, PatientWeightResponseDTO>(MemberList.None);
            #endregion

            #region Patient Temperature

            CreateMap<CreateOrUpdatePatientTemperatureRequestDTO, PatientTemperature>(MemberList.None);
            CreateMap<PatientTemperatureDeleteRequestDTO, PatientTemperature>(MemberList.None);

            CreateMap<PatientTemperature, PatientTemperatureResponseDTO>(MemberList.None);
            #endregion

            CreateMap<GetAllPatientVitalsHistory, VitalsPatientHistoryResponseDTO>(MemberList.None);
            #endregion

            #region Blogs

            #region Categories

            CreateMap<CreateOrUpdateCategoriesRequestDTO, Categories>(MemberList.None);
            CreateMap<Categories, CategoriesResponseDTO>(MemberList.None);
            #endregion

            #endregion

        }
    }
}
