using iHakeem.Domain.EMR.CurrentMedication.IDomainRepository;
using iHakeem.Domain.EMR.DetailPregnancies.IDomainRepository;
using iHakeem.Domain.EMR.ExerciseHistory.IDomainRepository;
using iHakeem.Domain.EMR.HospitalizationInformation.IDomainRepository;
using iHakeem.Domain.EMR.MyPhysicians.IDomainRepository;
using iHakeem.Domain.EMR.PatientAllergiesHistory.IDomainRepository;
using iHakeem.Domain.EMR.PatientFamilyHistory.IDomainRepository;
using iHakeem.Domain.EMR.PatientHobbiesHistory.IDomainRepository;
using iHakeem.Domain.EMR.PatientMedicalHistory.IDomainRepository;
using iHakeem.Domain.EMR.PharmacyInformation.IDomainRepository;
using iHakeem.Domain.EMR.PregnanciesHistory.IDomainRepository;
using iHakeem.Domain.EMR.RecreationalDrugsHistory.IDomainRepository;
using iHakeem.Domain.EMR.SocialHistory.IDomainRepository;
using iHakeem.Domain.EMR.SurgicalHistory.IDomainRepository;
using iHakeem.Domain.Models;
using iHakeem.Domain.Patients.IApplicationService;
using iHakeem.Infrastructure.Common;
using iHakeem.Infrastructure.Common.Exceptions;
using iHakeem.Infrastructure.Security.Abstractions;
using iHakeem.SharedKernal;
using iHakeem.SharedKernal.Constants;
using iHakeem.SharedKernal.Domain.IUnitOfWork;
using iHakeem.SharedKernal.Enums;
using iHakeem.SharedKernal.Utils;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace iHakeem.Domain.Patients.ApplicationService
{
    public class EMRPatientHistoryService : IEMRPatientHistoryService
    {

        private readonly ICurrentMedicationRepository _currentMedicationRepository;
        private readonly IExerciseHistoryRepository _exerciseHistoryRepository;
        private readonly IHospitalizationInformationRepository _hospitalizationInformationRepository;
        private readonly IMyPhysiciansRepository _myPhysiciansRepository;
        private readonly IPatientAllergiesHistoryRepository _patientAllergiesHistoryRepository;
        private readonly IPatientMedicalHistoryRepository _patientMedicalHistoryRepository;
        private readonly IPharmacyInformationRepository _pharmacyInformationRepository;
        private readonly IRecreationalDrugsHistoryRepository _recreationalDrugsHistoryRepository;
        private readonly ISocialHistoryRepository _socialHistoryRepository;
        private readonly ISurgicalHistoryRepository _surgicalHistoryRepository;
        private readonly IPatientFamilyHistoryRepository _patientFamilyHistoryRepository;
        private readonly IPatientHobbiesHistoryRepository _PatientHobbiesHistoryRepository;
        private readonly IPregnanciesHistoryRepository _PregnanciesHistoryRepository;
        private readonly IDetailPregnanciesRepository _DetailPregnanciesRepository;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IUnitOfWork _unitOfWork;
        private readonly CommonMethods _commonMethods;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EMRPatientHistoryService(
            ICurrentMedicationRepository currentMedicationRepository,
            IExerciseHistoryRepository exerciseHistoryRepository,
            IHospitalizationInformationRepository hospitalizationInformationRepository,
            IMyPhysiciansRepository myPhysiciansRepository,
            IPatientAllergiesHistoryRepository patientAllergiesHistoryRepository,
            IPatientMedicalHistoryRepository patientMedicalHistoryRepository,
            IPharmacyInformationRepository pharmacyInformationRepository,
            IRecreationalDrugsHistoryRepository recreationalDrugsHistoryRepository,
            ISocialHistoryRepository socialHistoryRepository,
            ISurgicalHistoryRepository surgicalHistoryRepository,
            IPatientFamilyHistoryRepository patientFamilyHistoryRepository,
            IPatientHobbiesHistoryRepository PatientHobbiesHistoryRepository,
            IPregnanciesHistoryRepository PregnanciesHistoryRepository,
            IDetailPregnanciesRepository DetailPregnanciesRepository,
            IDateTimeProvider dateTimeProvider,
            IUnitOfWork unitOfWork,
            IHttpContextAccessor httpContextAccessor)
        {
            _currentMedicationRepository = currentMedicationRepository;
            _exerciseHistoryRepository = exerciseHistoryRepository;
            _hospitalizationInformationRepository = hospitalizationInformationRepository;
            _myPhysiciansRepository = myPhysiciansRepository;
            _patientAllergiesHistoryRepository = patientAllergiesHistoryRepository;
            _patientMedicalHistoryRepository = patientMedicalHistoryRepository;
            _pharmacyInformationRepository = pharmacyInformationRepository;
            _recreationalDrugsHistoryRepository = recreationalDrugsHistoryRepository;
            _socialHistoryRepository = socialHistoryRepository;
            _surgicalHistoryRepository = surgicalHistoryRepository;
            _patientFamilyHistoryRepository = patientFamilyHistoryRepository;
            _PatientHobbiesHistoryRepository = PatientHobbiesHistoryRepository;
            _PregnanciesHistoryRepository = PregnanciesHistoryRepository;
            _DetailPregnanciesRepository = DetailPregnanciesRepository;
            _dateTimeProvider = dateTimeProvider;
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
            _commonMethods = new CommonMethods(_httpContextAccessor);
        }

        public async Task<GetAllPatientHistory> GetAllEMRPatientHistory(GetAllPatientHistory patientHistory)
        {
            var patientId = _commonMethods.GetClaim(ClaimConstant.ReferenceId);
            patientHistory.CurrentMedication = await _currentMedicationRepository.GetAll(s => s.PatientId == patientId && s.IsDeleted == false);
            patientHistory.ExerciseHistory = await _exerciseHistoryRepository.GetAll(s => s.PatientId == patientId && s.IsDeleted == false);
            patientHistory.HospitalizationInformation = await _hospitalizationInformationRepository.GetAll(s => s.PatientId == patientId && s.IsDeleted == false);
            patientHistory.MyPhysicians = await _myPhysiciansRepository.GetAll(s => s.PatientId == patientId && s.IsDeleted == false);
            patientHistory.PatientAllergies = await _patientAllergiesHistoryRepository.GetAll(s => s.PatientId == patientId && s.IsDeleted == false);
            patientHistory.PatientMedicalHistory = await _patientMedicalHistoryRepository.GetAll(s => s.PatientId == patientId && s.IsDeleted == false);
            patientHistory.PharmacyInformation = await _pharmacyInformationRepository.GetAll(s => s.PatientId == patientId && s.IsDeleted == false);
            patientHistory.RecreationalDrugsHistory = await _recreationalDrugsHistoryRepository.GetAll(s => s.PatientId == patientId && s.IsDeleted == false);
            patientHistory.SocialHistory = await _socialHistoryRepository.GetAll(s => s.PatientId == patientId && s.IsDeleted == false);
            patientHistory.SurgicalHistory = await _surgicalHistoryRepository.GetAll(s => s.PatientId == patientId && s.IsDeleted == false);
            patientHistory.PatientFamilyHistory = await _patientFamilyHistoryRepository.GetAll(s => s.PatientId == patientId && s.IsDeleted == false);
            patientHistory.PatientHobbiesHistory = await _PatientHobbiesHistoryRepository.GetAll(s => s.PatientId == patientId && s.IsDeleted == false);
            patientHistory.PregnanciesHistory = await _PregnanciesHistoryRepository.GetAll(s => s.PatientId == patientId && s.IsDeleted == false);
            patientHistory.DetailPregnancies = await _DetailPregnanciesRepository.GetAll(s => s.PatientId == patientId && s.IsDeleted == false);
            return patientHistory;

        }
    }
}
