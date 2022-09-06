using iHakeem.Domain.Models;
using System.Threading.Tasks;

namespace iHakeem.Domain.Patients.IApplicationService
{
    public interface IPatientApplicationService
    {
        Task<Patient> RegisterPatient(Patient patient, string password, long roleId);
        Task<Patient> GetPatientByUserId(long UserId);
    }
}
