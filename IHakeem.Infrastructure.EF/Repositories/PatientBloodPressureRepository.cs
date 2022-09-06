using System;
using iHakeem.Database.AppDbContext;
using iHakeem.Domain.MyVitals.PatientBloodPressure.IDomainRepository;
using iHakeem.Domain.Models;
using iHakeem.Domain.Users.IDomainRepository;
using iHakeem.Infrastructure.EF.Repository;

namespace iHakeem.Infrastructure.EF.Repositories
{
    public class PatientBloodPressureRepository : BaseRepository<PatientBloodPressure>, IPatientBloodPressureRepository
    {

        public PatientBloodPressureRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
