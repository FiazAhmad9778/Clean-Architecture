using iHakeem.Database.AppDbContext;
using iHakeem.Domain.Doctors.LicenseAndCertification.IDomainRepository;
using iHakeem.Domain.Models;
using iHakeem.Infrastructure.EF.Repository;

namespace iHakeem.Infrastructure.EF.Repositories
{
    public class DoctorLicenseAndCertificationRepository : BaseRepository<DoctorLicenseAndCertification>, IDoctorLicenseAndCertificationRepository
    {

        public DoctorLicenseAndCertificationRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

    }
}

