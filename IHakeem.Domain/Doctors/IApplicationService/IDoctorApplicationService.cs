using iHakeem.Domain.Models;
using System.Threading.Tasks;

namespace iHakeem.Domain.Doctors.IApplicationService
{
    public interface IDoctorApplicationService
    {
        Task<Doctor> RegisterDoctor(Doctor Doctor, string password, long roleId);

    }
}
