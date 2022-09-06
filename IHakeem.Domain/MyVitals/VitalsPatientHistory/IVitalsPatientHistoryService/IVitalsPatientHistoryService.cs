using iHakeem.Domain.Models;
using System.Threading.Tasks;

namespace iHakeem.Domain.Patients.IApplicationService
{
    public interface IVitalsPatientHistoryService
    {
        Task<GetAllPatientVitalsHistory> GetAllVitalsPatientHistory(GetAllPatientVitalsHistory patientHistory);
    }
}
