using iHakeem.Domain.Models;
using iHakeem.Domain.MyVitals.PatientBloodPressure.IDomainRepository;
using iHakeem.Domain.MyVitals.PatientTemperature.IDomainRepository;
using iHakeem.Domain.MyVitals.PatientWeight.IDomainRepository;
using iHakeem.Domain.MyVitals.PulseOximeter.IDomainRepository;
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
    public class VitalsPatientHistoryService : IVitalsPatientHistoryService
    {

        private readonly IPatientBloodPressureRepository _PatientBloodPressureRepository;
        private readonly IPatientTemperatureRepository _PatientTemperatureRepository;
        private readonly IPatientWeightRepository _PatientWeightRepository;
        private readonly IPulseOximeterRepository _PulseOximeterRepository;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IUnitOfWork _unitOfWork;
        private readonly CommonMethods _commonMethods;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public VitalsPatientHistoryService(
            IPatientBloodPressureRepository PatientBloodPressureRepository,
            IPatientTemperatureRepository PatientTemperatureRepository,
            IPatientWeightRepository PatientWeightRepository,
            IPulseOximeterRepository PulseOximeterRepository,
            IDateTimeProvider dateTimeProvider,
            IUnitOfWork unitOfWork,
            IHttpContextAccessor httpContextAccessor)
        {
            _PatientBloodPressureRepository = PatientBloodPressureRepository;
            _PatientTemperatureRepository = PatientTemperatureRepository;
            _PatientWeightRepository = PatientWeightRepository;
            _PulseOximeterRepository = PulseOximeterRepository;
            _dateTimeProvider = dateTimeProvider;
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
            _commonMethods = new CommonMethods(_httpContextAccessor);
        }

        public async Task<GetAllPatientVitalsHistory> GetAllVitalsPatientHistory(GetAllPatientVitalsHistory patientHistory)
        {
            var patientId = _commonMethods.GetClaim(ClaimConstant.ReferenceId);
            patientHistory.PatientBloodPressure = await _PatientBloodPressureRepository.GetAll(s => s.PatientId == patientId && s.IsDeleted == false);
            patientHistory.PatientTemperature = await _PatientTemperatureRepository.GetAll(s => s.PatientId == patientId && s.IsDeleted == false);
            patientHistory.PatientWeight = await _PatientWeightRepository.GetAll(s => s.PatientId == patientId && s.IsDeleted == false);
            patientHistory.PulseOximeter = await _PulseOximeterRepository.GetAll(s => s.PatientId == patientId && s.IsDeleted == false);
            return patientHistory;

        }
    }
}
