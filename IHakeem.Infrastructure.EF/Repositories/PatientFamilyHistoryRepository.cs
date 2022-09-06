using System;
using iHakeem.Database.AppDbContext;
using iHakeem.Domain.EMR.PatientFamilyHistory.IDomainRepository;
using iHakeem.Domain.Models;
using iHakeem.Domain.Users.IDomainRepository;
using iHakeem.Infrastructure.EF.Repository;

namespace iHakeem.Infrastructure.EF.Repositories
{
    public class PatientFamilyHistoryRepository : BaseRepository<PatientFamilyHistory>, IPatientFamilyHistoryRepository
    {

        public PatientFamilyHistoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
