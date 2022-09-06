using System;
using iHakeem.Database.AppDbContext;
using iHakeem.Domain.MyVitals.PatientTemperature.IDomainRepository;
using iHakeem.Domain.Models;
using iHakeem.Domain.Users.IDomainRepository;
using iHakeem.Infrastructure.EF.Repository;

namespace iHakeem.Infrastructure.EF.Repositories
{
    public class PatientTemperatureRepository : BaseRepository<PatientTemperature>, IPatientTemperatureRepository
    {

        public PatientTemperatureRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
