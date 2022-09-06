using iHakeem.Domain.Models;
using System.Threading.Tasks;

namespace iHakeem.Domain.Patients.IApplicationService
{
    public interface IEMRPatientHistoryService
    {
        Task<GetAllPatientHistory> GetAllEMRPatientHistory(GetAllPatientHistory patientHistory);
    }
}
