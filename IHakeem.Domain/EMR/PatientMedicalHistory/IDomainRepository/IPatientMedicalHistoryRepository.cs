using PatientHistory=iHakeem.Domain.Models.PatientMedicalHistory;
using iHakeem.SharedKernal.Domain.IRepository;

namespace iHakeem.Domain.EMR.PatientMedicalHistory.IDomainRepository
{
    public interface IPatientMedicalHistoryRepository
        : IBaseRepository<PatientHistory>
    {
    }


}
