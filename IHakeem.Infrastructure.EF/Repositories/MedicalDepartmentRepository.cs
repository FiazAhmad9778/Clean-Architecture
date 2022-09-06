using iHakeem.Database.AppDbContext;
using iHakeem.Domain.Departments.IDomainRepository;
using iHakeem.Domain.Models;
using iHakeem.Infrastructure.EF.Repository;
using System.Linq;

namespace iHakeem.Infrastructure.EF.Repositories
{
    public class MedicalDepartmentRepository
        : BaseRepository<MedicalDepartment>, IMedicalDepartmentRepository
    {
        public MedicalDepartmentRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }


    }
}
