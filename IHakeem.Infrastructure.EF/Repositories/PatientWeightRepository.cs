using System;
using iHakeem.Database.AppDbContext;
using iHakeem.Domain.MyVitals.PatientWeight.IDomainRepository;
using iHakeem.Domain.Models;
using iHakeem.Domain.Users.IDomainRepository;
using iHakeem.Infrastructure.EF.Repository;

namespace iHakeem.Infrastructure.EF.Repositories
{
    public class PatientWeightRepository : BaseRepository<PatientWeight>, IPatientWeightRepository
    {

        public PatientWeightRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
